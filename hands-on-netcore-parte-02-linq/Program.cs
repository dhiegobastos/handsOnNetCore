using System;
using System.Collections.Generic;
using System.Linq;
using hands_on_netcore.Model;
using hands_on_netcore_parte_02_linq.Service;

namespace hands_on_netcore_parte_02_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var turmas = TurmaService.ObterTurmas();

            // Quantidade de alunos em todas as turmas
            var quatidadeAlunos = turmas.SelectMany(turma => turma.Alunos).Count();
            //ou
            //Console.WriteLine(turmas.Sum(t => t.Alunos.Count));
            Console.WriteLine($"1) Quantidade de alunos em todas as turmas: {quatidadeAlunos}");

            // Maior Nota entre todos os alunos
            var maiorNota = turmas.SelectMany(turma => turma.Alunos).Max(aluno => aluno.Nota);
            //ou
            //Console.WriteLine(turmas.Max(t => t.Alunos.Max(a => a.Nota)));
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

            Console.WriteLine($"5) Média de nota por turma: {String.Join("; ", mediaNotaAlunoPorTurma.Select(x => x.Media))}");

            var maiorTurma = turmas.Aggregate((curMin, x) => curMin.Alunos.Count() > x.Alunos.Count() ? curMin : x);
            Console.WriteLine($"6) Turma que tem o maior número de alunos: {maiorTurma.NomeTurma} - Quantidade de alunos: {maiorTurma.Alunos.Count()}");

            var quantidadeMulheres = (from turma in turmas
                                      from aluna in turma.Alunos
                                      where aluna.Sexo.Equals("F")
                                      group aluna by aluna.Id into grupo
                                      where grupo.Count() > 1
                                      select grupo).Count();
            //ou
            //var quantidadeMulheres = turmas.SelectMany(t => t.Alunos).Where(a => a.Sexo == "F")
            //.GroupBy(a => a.Id).Where(g => g.Count() > 1).Count();
            Console.WriteLine($"7) Quantidade de alunas que estão em mais de uma turma: {quantidadeMulheres}");
        }
    }
}
