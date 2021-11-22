using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domains.Models
{
    public class Ask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int QuestId { get; set; } 
        public Quest Quest { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
