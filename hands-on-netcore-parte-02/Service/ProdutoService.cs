using System;
using System.Collections.Generic;
using hands_on_netcore.Model.Domain;
using hands_on_netcore.Repository.Interface;

namespace hands_on_netcore.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IList<Produto> ObterProdutos()
        {
            return _produtoRepository.ObterProdutos();
        }

        public Produto ObterProdutoPorId(int id)
        {
            return _produtoRepository.ObterProdutoPorId(id);
        }

        public Produto AddProduto(Produto produto)
        {
            return _produtoRepository.InserirProduto(produto);
        }

    }
}