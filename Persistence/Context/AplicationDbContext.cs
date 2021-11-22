using BackEnd.Domains.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Context
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ask> Ask { get; set; }
        public DbSet<Quest> Quest { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<QuestAnswer> QuestAnswer{ get; set; }
        public DbSet<QuestAnswerDetail> QuestAnswerDetail { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options):base(options)
        {

        }
    }
}
