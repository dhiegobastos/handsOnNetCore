using System.Collections.Generic;
using hands_on_netcore.Model.Domain;

namespace hands_on_netcore.Repository.Interface
{
    public interface IProdutoRepository
    {
        IList<Produto> ObterProdutos();
        Produto ObterProdutoPorId(int id);
        Produto InserirProduto(Produto produto);
    }
}