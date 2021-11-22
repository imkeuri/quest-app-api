using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.DTO
{
    public class ChangePasswordDto
    {
        public string oldPass { get; set; }
        public string newPass { get; set; }
    }
}
