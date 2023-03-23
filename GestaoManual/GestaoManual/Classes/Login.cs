using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestaoManual.Classes
{
    public class Login
    {
        public int Id { get; set; }
        public int AleatorioNum { get; set; }
        public string Email { get; set; } 
    }
}