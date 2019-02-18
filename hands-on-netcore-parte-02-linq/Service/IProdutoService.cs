using System.Collections.Generic;
using hands_on_netcore.Model;

namespace hands_on_netcore.Service
{
    public interface IProdutoService
    {
        List<Produto> ObterProdutos();
        Produto ObterProdutoPorId(int id);
        void AddProduto(Produto produto);
    }
}