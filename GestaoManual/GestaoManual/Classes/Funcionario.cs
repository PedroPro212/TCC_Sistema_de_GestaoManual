using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Classes
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataN { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public int Setor { get; set; }
    }
}