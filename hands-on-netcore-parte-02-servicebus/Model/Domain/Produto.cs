namespace hands_on_netcore.Model.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int QtdEstoque { get; set; }
        public string UltimaCompra { get; set; }
        public bool Ativo { get; set; }
    }
}