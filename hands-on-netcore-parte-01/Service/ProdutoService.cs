using System;
using System.Collections.Generic;
using hands_on_netcore.Model;

namespace hands_on_netcore.Service
{
    public class ProdutoService : IProdutoService
    {
        private List<Produto> lista = new List<Produto>();

        public ProdutoService(int qtdProdutos)
        {
            for (int i = 1; i < qtdProdutos; i++)
            {
                lista.Add(new Produto(i, i * 100, "Produto 0" + i, i * 10, "2019-02-13T11:58:00", Convert.ToBoolean(i % 2)));
            }
        }

        public List<Produto> ObterProdutos()
        {
            return lista;
        }

        public Produto ObterProdutoPorId(int id)
        {
            return lista.Find(v => v.Id == id);
        }

        public void AddProduto(Produto produto)
        {
            lista.Add(produto);
        }

    }
}