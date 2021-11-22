using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domains.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public int Active { get; set; }
        public int UsuarioId { get; set; }
       
        public Usuario Usuario { get; set; }
        public List<Ask> Asks { get; set; } = new List<Ask>();

    }
}
