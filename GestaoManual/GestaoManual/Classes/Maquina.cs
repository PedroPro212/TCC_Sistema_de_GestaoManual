using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Classes
{
    public class Maquina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int idSetor { get; set; }
        public int idEncarregado { get; set; }
    }
}