using BackEnd.Domains.IRepositories;
using BackEnd.Domains.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Repositories
{
    public class AnswerQuestRepository : IAnswerQuestRepository
    {
        private readonly AplicationDbContext dbContext;
        public AnswerQuestRepository( AplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task DeleteQuestAnser(QuestAnswer questAnswer)
        {
            questAnswer.Active = 0;
            dbContext.Entry(questAnswer).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<QuestAnswerDetail>> GetAnswerDetailsList(int idAnswer)
        {
            var result = await dbContext.QuestAnswerDetail.Where(x => x.AnswerQuestId == idAnswer && x.QuestAnswer.Active == 1)
                                                                                        .Select(x => new QuestAnswerDetail{
                                                                                            AnswerId = x.AnswerId
                                                                                        })
                                                                                        .ToListAsync();
            return result;
        }

        public async Task<List<QuestAnswer>> GetQuestAnswers(int idQuest, int idUser)
        {
            var list = await dbContext.QuestAnswer.Where(c => c.QuestId == idQuest  
                                                            && c.Active == 1 
                                                            && c.Quest.UsuarioId == idUser)
                                                            .OrderBy(c => c.Date)
                                                            .ToListAsync();
            return list;
        }

        public async Task<int> GetQuestId(int idAnswer)
        {
            var result = await dbContext.QuestAnswer.Where( x=> x.id == idAnswer && x.Active == 1).FirstOrDefaultAsync();
            return (result.QuestId);
        }

        public async Task SaveAnswerQuest(QuestAnswer questAnswer) 
        {
            questAnswer.Active = 1;
            questAnswer.Date = DateTime.Now;
            dbContext.Add(questAnswer);
            await dbContext.SaveChangesAsync();
        }

        public async Task<QuestAnswer> SearchQuestAnswer(int id, int idUser)
        {
            var delete = await dbContext.QuestAnswer.Where(x => x.id == id 
                                                             && x.Quest.UsuarioId == idUser)
                                                                 .FirstOrDefaultAsync();
            
            return delete;
        }
    }
}
