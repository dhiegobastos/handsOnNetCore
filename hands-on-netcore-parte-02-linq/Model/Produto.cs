namespace hands_on_netcore.Model
{
    public class Produto
    {
        public Produto(int id, double valor, string nome, int qtd_estoque,
                string ultima_compra, bool ativo)
        {
            Id = id;
            Valor = valor;
            Nome = nome;
            QtdEstoque = qtd_estoque;
            UltimaCompra = ultima_compra;
            Ativo = ativo;
        }

        public int Id { get; set; }
        public double Valor { get; set; }
        public string Nome { get; set; }
        public int QtdEstoque { get; set; }
        public string UltimaCompra { get; set; }
        public bool Ativo { get; set; }
        public string Campo1 { get; set; }
        public string Campo2 { get; set; }
        public string Campo3 { get; set; }
        public string Campo4 { get; set; }
        public string Campo5 { get; set; }
    }
}