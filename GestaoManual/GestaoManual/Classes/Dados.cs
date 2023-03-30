using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Classes
{
    public class Dados
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNas { get; set; }
        public string Email { get; set;}
        public string Tel { get; set;}
        public string Senha { get; set;}
    }
}