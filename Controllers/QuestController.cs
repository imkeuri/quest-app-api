using BackEnd.Domains.IServices;
using BackEnd.Domains.Models;
using BackEnd.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        private readonly IQuestService questService;

        public QuestController(IQuestService questService)
        {
            this.questService = questService;
        }

     
        
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> Post( Quest quest)
        {
          
            try
            {
               
                if (quest == null)
                {
                    return BadRequest(new { message = "No se" });
                }
                else
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int IdUser = JwtConfigurator.GetTokenUsuarioId(identity);

                    quest.UsuarioId = IdUser;
                    quest.Active = 1;
                    quest.DateCreated = DateTime.Now;
                    await questService.CreateQuest(quest);
                    return Ok(new { message = "Quest added correctly" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        
        [Route("GetListQuestByUser")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task <IActionResult> GetListQuestByUser()
        {
            try
            {

                

                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int IdUser = JwtConfigurator.GetTokenUsuarioId(identity);

               var questList = await questService.GetListQuestByUser(IdUser);
                return Ok( questList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
      
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var quest = await questService.GetQuest(id);
                return Ok(quest);
            }
            catch (Exception ex)
            {
                 
               return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int IdUser = JwtConfigurator.GetTokenUsuarioId(identity);
                var quest = await questService.SearchQuest(id, IdUser);
                if(quest == null)
                {
                    return BadRequest(new { message = "Quest not found" });
                }
               
               
                   await questService.DeleteQuest(quest);
                return Ok(new { message = "Quest deleted correctly" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("GetList")]
        [HttpGet]
        public async Task<IActionResult> GetListQuest()
        {
            try
            {
                var listQuest = await questService.GetListQuest();
                return Ok(listQuest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

    }
}
