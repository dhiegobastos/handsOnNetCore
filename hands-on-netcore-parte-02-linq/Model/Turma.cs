using System;
using System.Collections.Generic;
using System.Linq;

namespace hands_on_netcore.Model
{
    public class Turma
    {
        public int Id { get; set; }
        public string NomeTurma { get; set; }
        public IList<Aluno> Alunos { get; set; }
    }
}