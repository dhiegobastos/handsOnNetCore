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

        public IList<Turma> ObterTurmas() => new List<Turma>
            {
                new Turma
                {
                    Id = 1,
                    NomeTurma = "Turma 1",
                    Alunos = new List<Aluno>
                    {
                        new Aluno
                        {
                            Id = 1,
                            TurmaId = 1,
                            Nome = "Aluno 1",
                            Sexo = "M"
                        },
                        new Aluno
                        {
                            Id = 2,
                            TurmaId = 1,
                            Nome = "Aluno 2",
                            Sexo = "F"
                        },
                        new Aluno
                        {
                            Id = 3,
                            TurmaId = 1,
                            Nome = "Aluno 3",
                            Sexo = "F"
                        }
                    }
                },
                new Turma
                {
                    Id = 2,
                    NomeTurma = "Turma 2",
                    Alunos = new List<Aluno>
                    {
                        new Aluno
                        {
                            Id = 4,
                            TurmaId = 2,
                            Nome = "Aluno 4",
                            Sexo = "M"
                        },
                        new Aluno
                        {
                            Id = 5,
                            TurmaId = 2,
                            Nome = "Aluno 5",
                            Sexo = "M"
                        },
                        new Aluno
                        {
                            Id = 2,
                            TurmaId = 2,
                            Nome = "Aluno 2",
                            Sexo = "F"
                        }
                    }
                },
                new Turma
                {
                    Id = 3,
                    NomeTurma = "Turma 3",
                    Alunos = new List<Aluno>
                    {
                        new Aluno
                        {
                            Id = 7,
                            TurmaId = 3,
                            Nome = "Aluno 7",
                            Sexo = "F"
                        },
                        new Aluno
                        {
                            Id = 8,
                            TurmaId = 3,
                            Nome = "Aluno 8",
                            Sexo = "M"
                        },
                        new Aluno
                        {
                            Id = 9,
                            TurmaId = 3,
                            Nome = "Aluno 9",
                            Sexo = "F"
                        }
                    }
                }
            };
    }
}