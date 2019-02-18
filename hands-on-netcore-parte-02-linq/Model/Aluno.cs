using System;
using System.Collections.Generic;
using System.Linq;

namespace hands_on_netcore.Model
{
    public class Aluno
    {
        public int Id { get; set; }
        public int TurmaId { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; }
        public int Nota { get; set; }

    }
}