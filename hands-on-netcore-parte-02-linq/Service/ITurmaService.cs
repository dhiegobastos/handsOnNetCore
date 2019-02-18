using System.Collections.Generic;
using hands_on_netcore.Model;

namespace hands_on_netcore.Service
{
    public interface ITurmaService
    {
        void ExecutarRegrasTurma();
        IList<Turma> ObterTurmas();
    }
}