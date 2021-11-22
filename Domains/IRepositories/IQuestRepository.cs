using BackEnd.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domains.IRepositories
{
   public interface IQuestRepository
    {
        Task CreateQuest(Quest quest);
        Task <List<Quest>>GetListQuestByUser(int id);
        Task<Quest> GetQuest(int id);
        Task<Quest> SearchQuest(int id, int idUSer);
        Task DeleteQuest(Quest quest);
        Task<List<Quest>> GetListQuest();
    }
}
