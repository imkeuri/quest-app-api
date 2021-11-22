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
    class QuestRepository : IQuestRepository
    {
        private readonly AplicationDbContext _contex;
        public QuestRepository( AplicationDbContext context)
        {
            _contex = context;
        }

        public async Task CreateQuest(Quest quest)
        {
            _contex.Add(quest);
            await _contex.SaveChangesAsync();
        }

        public async Task DeleteQuest(Quest quest)
        {
            quest.Active = 0;
            _contex.Entry(quest).State = EntityState.Modified;
            await _contex.SaveChangesAsync();
        }

        public async Task<List<Quest>> GetListQuest()
        {
            var ListQuest = await _contex.Quest.Where(x => x.Active == 1)
                                               .Select(o => new Quest
                                               {
                                                   Id = o.Id,
                                                   Name = o.Name,
                                                   Description = o.Description,
                                                   DateCreated = o.DateCreated,
                                                   Usuario = new Usuario
                                                   {
                                                       User = o.Usuario.User
                                                   }
                                               })
                                               .ToListAsync();
            return ListQuest;
        }

        public async Task<List<Quest>> GetListQuestByUser(int id)
        {
          var questByUser = await _contex.Quest.Where(x => x.Active == 1 && x.UsuarioId == id).ToListAsync();
          return questByUser;
        }

        public async Task<Quest> GetQuest(int id)
        {
            var quest = await _contex.Quest.Where(x => x.Id == id 
                                                && x.Active ==1)
                                                .Include(x => x.Asks)
                                                .ThenInclude(x => x.Answers)
                                                .FirstOrDefaultAsync();

            return quest;
        }

        public async  Task<Quest> SearchQuest(int id, int idUser)
        {
            var quest = await _contex.Quest.Where(x => x.Id == id
                                                    && x.Active == 1
                                                    && x.UsuarioId == idUser).FirstOrDefaultAsync();
            return quest;
        }
    }
}
