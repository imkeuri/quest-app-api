using BackEnd.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domains.IServices
{
    public interface IAnswerQuestService
    {
        Task SaveAnswerQuest(QuestAnswer questAnswer);
        Task<List<QuestAnswer>> GetQuestAnswers(int idQuest, int idUser);
        Task<QuestAnswer> SearchQuestAnswer(int id, int idUser);
        Task DeleteQuestAnser(QuestAnswer questAnswer);       
        Task <int> GetQuestId(int idAnswer);
        Task<List<QuestAnswerDetail>> GetAnswerDetailsList (int idAnswer);
        
    }
}
