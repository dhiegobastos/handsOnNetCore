using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using hands_on_netcore.Model.Domain;
using hands_on_netcore.Repository.Interface;
using Microsoft.Extensions.Configuration;

namespace hands_on_netcore.Repository
{
    public class ProdutoRepository : MySqlBaseRepository, IProdutoRepository
    {
        public ProdutoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Produto InserirProduto(Produto produto)
        {
            string sql = @"INSERT INTO TBL_PRODUTO 
                                    (NOM_PRODUTO, VLR_VENDA, QTD_ESTOQUE, DT_ULTIMA_COMPRA, ATIVO)
                                VALUES (@NomeProduto, @Valor, @QtdEstoque, @UltimaCompra, @Ativo);
                           SELECT LAST_INSERT_ID();";

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@NomeProduto", produto.Nome);
            parametros.Add("@Valor", produto.Valor);
            parametros.Add("@QtdEstoque", produto.QtdEstoque);
            parametros.Add("@UltimaCompra", produto.UltimaCompra);
            parametros.Add("@Ativo", produto.Ativo);

            using (IDbConnection connection = GetIDbConnection())
            {
                int id = connection.QuerySingle<int>(sql, parametros);
                return ObterProdutoPorId(id);
            }
        }

        public Produto ObterProdutoPorId(int id)
        {
            string sql = @"SELECT 
                                COD_PRODUTO as Id,
                                NOM_PRODUTO as Nome,
                                VLR_VENDA as Valor,
                                QTD_ESTOQUE as QtdEstoque,
                                DATE_FORMAT(DT_ULTIMA_COMPRA, '%d/%m/%Y') as UltimaCompra,
                                ATIVO as Ativo
                           FROM TBL_PRODUTO
                           WHERE COD_PRODUTO = @CodigoProduto";

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@CodigoProduto", id);

            using (IDbConnection connection = GetIDbConnection())
            {
                try
                {
                    return connection.QuerySingle<Produto>(sql, parametros);
                }
                catch (InvalidOperationException ex)
                {
                    return null;
                }
            }
        }

        public IList<Produto> ObterProdutos()
        {
            string sql = @"SELECT 
                                COD_PRODUTO as Id,
                                NOM_PRODUTO as Nome,
                                VLR_VENDA as Valor,
                                QTD_ESTOQUE as QtdEstoque,
                                DATE_FORMAT(DT_ULTIMA_COMPRA, '%d/%m/%Y') as UltimaCompra,
                                ATIVO as Ativo
                           FROM TBL_PRODUTO";

            using (IDbConnection connection = GetIDbConnection())
            {
                return connection.Query<Produto>(sql).ToList();
            }
        }
    }
}