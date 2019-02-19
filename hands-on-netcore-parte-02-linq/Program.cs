using System;
using System.Collections.Generic;
using System.Linq;
using hands_on_netcore.Model;

namespace hands_on_netcore_parte_02_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var turmas = ObterTurmas();

            // Quantidade de alunos em todas as turmas
            var quatidadeAlunos = turmas.SelectMany(turma => turma.Alunos).Count();
            Console.WriteLine($"1) Quantidade de alunos em todas as turmas: {quatidadeAlunos}");

            // Maior Nota entre todos os alunos
            var maiorNota = turmas.SelectMany(turma => turma.Alunos).Max(aluno => aluno.Nota);
            Console.WriteLine($"2) Maior Nota entre todos os alunos: {maiorNota}");

            // Quantidade de alunos do sexo masculino
            var alunosM = turmas.SelectMany(turma => turma.Alunos).Where(aluno => aluno.Sexo.Equals("M")).Count();
            Console.WriteLine($"3) Quantidade de alunos do sexo masculino: {alunosM}");

            // Media de nota por turma
            var mediaNotaAlunoPorTurma = (from turma in turmas
                                          select new
                                          {
                                              turma.NomeTurma,
                                              Media = turma.Alunos.Average(x => x.Nota)
                                          }
                                        );

            Console.WriteLine($"4) Média nota por turma:");
            foreach (var turma in mediaNotaAlunoPorTurma)
            {
                Console.WriteLine($"\tTurma: {turma.NomeTurma} - Média: {turma.Media}");
            }

            Console.WriteLine($"5) Media de nota por turma: {String.Join("; ", mediaNotaAlunoPorTurma.Select(x => x.Media))}");

            var maiorTurma = turmas.Aggregate((curMin, x) => curMin.Alunos.Count() > x.Alunos.Count() ? curMin : x);
            Console.WriteLine($"6) Turma que tem o maior número de alunos: {maiorTurma.NomeTurma} - Quantidade de alunos: {maiorTurma.Alunos.Count()}");

            var quantidadeMulheres = (from turma in turmas
                                      from aluna in turma.Alunos
                                      where aluna.Sexo.Equals("F")
                                      group aluna by aluna.Id into grupo
                                      where grupo.Count() > 1
                                      select grupo).Count();

            Console.WriteLine($"7) Quantidade de alunas que estão em mais de uma turma: {quantidadeMulheres}");
        }

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
                            TurmaId = 1,
                            Nome = "Aluno 1",
                            Sexo = "M",
                            Nota = 80
                        },
                        new Aluno
                        {
                            Id = 2,
                            TurmaId = 1,
                            Nome = "Aluno 2",
                            Sexo = "F",
                            Nota = 95
                        },
                        new Aluno
                        {
                            Id = 3,
                            TurmaId = 1,
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
                            TurmaId = 2,
                            Nome = "Aluno 4",
                            Sexo = "M",
                            Nota = 99
                        },
                        new Aluno
                        {
                            Id = 5,
                            TurmaId = 2,
                            Nome = "Aluno 5",
                            Sexo = "M",
                            Nota = 75
                        },
                        new Aluno
                        {
                            Id = 2,
                            TurmaId = 2,
                            Nome = "Aluno 2",
                            Sexo = "F",
                            Nota = 93
                        },
                        new Aluno
                        {
                            Id = 10,
                            TurmaId = 3,
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
                            TurmaId = 3,
                            Nome = "Aluno 7",
                            Sexo = "F",
                            Nota = 52
                        },
                        new Aluno
                        {
                            Id = 8,
                            TurmaId = 3,
                            Nome = "Aluno 8",
                            Sexo = "M",
                            Nota = 71
                        },
                        new Aluno
                        {
                            Id = 9,
                            TurmaId = 3,
                            Nome = "Aluno 9",
                            Sexo = "F",
                            Nota = 45
                        }
                    }
                }
            };
    }
}
