using BackEnd.Domains.IRepositories;
using BackEnd.Domains.IServices;
using BackEnd.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class QuestService : IQuestService
    {
        private readonly IQuestRepository questRepository;
        public QuestService(IQuestRepository questRepository)
        {
            this.questRepository = questRepository;
        }
        public async  Task CreateQuest(Quest quest)
        {
            await questRepository.CreateQuest(quest);
        }

        public async Task DeleteQuest(Quest quest)
        {
            await questRepository.DeleteQuest(quest);
        }

        public async Task<List<Quest>> GetListQuest()
        {
            return await questRepository.GetListQuest(); ;
        }

        public async Task<List<Quest>> GetListQuestByUser(int id)
        {
           var questByUser = await questRepository.GetListQuestByUser(id);
           return questByUser;
        }

        public async Task<Quest> GetQuest(int id)
        {
            var quest = await questRepository.GetQuest(id);
            return quest;
        }

        public async Task<Quest> SearchQuest(int id, int idUSer)
        {
            var quest = await questRepository.SearchQuest(id, idUSer);
            return quest;
        }
    }
}
