using System.Collections.Generic;
using hands_on_netcore.Model;

namespace hands_on_netcore_parte_02_linq.Service
{
    public class TurmaService
    {
        public static IList<Turma> ObterTurmas() => new List<Turma>
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
                            Nome = "Aluno 1",
                            Sexo = "M",
                            Nota = 80
                        },
                        new Aluno
                        {
                            Id = 2,
                            Nome = "Aluno 2",
                            Sexo = "F",
                            Nota = 95
                        },
                        new Aluno
                        {
                            Id = 3,
                            Nome = "Aluno 3",
                            Sexo = "F",
                            Nota = 62
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
                            Nome = "Aluno 4",
                            Sexo = "M",
                            Nota = 99
                        },
                        new Aluno
                        {
                            Id = 5,
                            Nome = "Aluno 5",
                            Sexo = "M",
                            Nota = 75
                        },
                        new Aluno
                        {
                            Id = 2,
                            Nome = "Aluno 2",
                            Sexo = "F",
                            Nota = 93
                        },
                        new Aluno
                        {
                            Id = 10,
                            Nome = "Aluno 10",
                            Sexo = "F",
                            Nota = 35
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
                            Nome = "Aluno 7",
                            Sexo = "F",
                            Nota = 52
                        },
                        new Aluno
                        {
                            Id = 8,
                            Nome = "Aluno 8",
                            Sexo = "M",
                            Nota = 71
                        },
                        new Aluno
                        {
                            Id = 9,
                            Nome = "Aluno 9",
                            Sexo = "F",
                            Nota = 45
                        }
                    }
                }
            };
    }
}