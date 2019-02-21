using System.Collections.Generic;
using hands_on_netcore.Model.Domain;

public interface IProdutoService
{
    IList<Produto> ObterProdutos();
    Produto ObterProdutoPorId(int id);
    Produto AddProduto(Produto produto);
}