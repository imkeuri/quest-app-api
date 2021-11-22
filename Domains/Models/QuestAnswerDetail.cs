using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domains.Models
{
    public class QuestAnswerDetail
    {
        public int Id { get; set; }
        public int AnswerQuestId { get; set; }
        public QuestAnswer QuestAnswer { get; set; }
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
