using BackEnd.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domains.IServices
{
    public interface IQuestService
    {
        Task CreateQuest(Quest quest);
        Task<List<Quest>> GetListQuestByUser(int id);
        Task<Quest> GetQuest(int id);
        Task<Quest> SearchQuest(int id, int idUser);
        Task DeleteQuest(Quest quest);
        Task<List<Quest>> GetListQuest();
    }
}
