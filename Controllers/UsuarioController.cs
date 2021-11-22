using BackEnd.Domains.IServices;
using BackEnd.Domains.Models;
using BackEnd.DTO;
using BackEnd.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

      


       public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Usuario usuario)
        {
            try
            {
                var validateUser = await _usuarioService.ValidateExistence(usuario);
                if (validateUser)
                {
                    return BadRequest(new { message = "User " + usuario.User + " already exists!!!" });
                }
                usuario.Password = Encrypt.EncryptPassword(usuario.Password);
                await _usuarioService.SaveUser(usuario);
                return Ok(new { message = $"{usuario.User} was register succesfull" });
            }
            catch (Exception ex )
            {

                return BadRequest(ex.Message);
            }
        }
        

        // localhost: xxx/api/Usuario/ChangePass
        [Route("ChangePass")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> ChangePass([FromBody] ChangePasswordDto changePasswordDto)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
 
                int IdUser = JwtConfigurator.GetTokenUsuarioId(identity); 

                string passEncrypt = Encrypt.EncryptPassword(changePasswordDto.oldPass);

                var user = await _usuarioService.ValidatePassword(IdUser, passEncrypt);
                
                if (user == null)
                {
                    return BadRequest(new { message = "Password is incorrect" });
                }
                else
                {
                    user.Password = Encrypt.EncryptPassword(changePasswordDto.newPass);
                    await _usuarioService.UpdatePassword(user);
                    return Ok(new { message = "New password was update sucessfully!!!" });
                }
                
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
