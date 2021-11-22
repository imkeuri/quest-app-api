using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domains.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool isCorrect { get; set; }
        public int AskId { get; set; }
        public Ask Ask { get; set; }
    }
}
