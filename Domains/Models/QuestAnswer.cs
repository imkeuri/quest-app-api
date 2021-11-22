using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domains.Models
{
    public class QuestAnswer
    {
        public int id { get; set; }
        public string NameParticipant { get; set; }
        public DateTime Date { get; set; }
        public int Active { get; set; }
        public int QuestId { get; set; }
        public Quest Quest { get; set; }
        public List<QuestAnswerDetail> QuestAnswerDetails { get; set; }
    }
}
