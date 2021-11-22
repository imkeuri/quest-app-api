using BackEnd.Domains.IServices;
using BackEnd.Domains.Models;
using BackEnd.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class AnswerQuestController : ControllerBase
    {
        private readonly IAnswerQuestService answerQuestService;
        private readonly IQuestService questService;
        public AnswerQuestController(IAnswerQuestService answerQuestService, IQuestService questService)
        {
            this.answerQuestService = answerQuestService;
            this.questService = questService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(QuestAnswer questAnswer)
        {
            try
            {
                if (questAnswer == null)
                {
                    return BadRequest();
                }
                await answerQuestService.SaveAnswerQuest(questAnswer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    
        [HttpGet("{idQuest}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(int idQuest)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                
                int idUser = JwtConfigurator.GetTokenUsuarioId(identity);

                var list = await answerQuestService.GetQuestAnswers(idQuest, idUser);


                if (list == null)
                {
                    return BadRequest(new { message = "No existen datos" });
                }

                return Ok(list);
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

                int idUser = JwtConfigurator.GetTokenUsuarioId(identity);
                var delete = await answerQuestService.SearchQuestAnswer(id, idUser);
                
                if (delete == null)
                {
                    return BadRequest(new { message = "Error al buscar la repuesta" });
                }

                 await  answerQuestService.DeleteQuestAnser(delete);

                return Ok(new { message = $"Answer {id} deleted succefull" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAnswerById/{id}")]
        [HttpGet]
     //   [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAnswerById(int id){
            try
            {
                 var idQuest = await answerQuestService.GetQuestId(id);

                 var quest = await questService.GetQuest(idQuest);
                
                 var lisAnswer = await answerQuestService.GetAnswerDetailsList(id);
                
                return Ok(new{quest = quest, answer = lisAnswer});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
