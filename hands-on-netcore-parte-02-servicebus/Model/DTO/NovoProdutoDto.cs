namespace hands_on_netcore.Model.DTO
{
    public class NovoProdutoDto
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public DetalheProdutoDto detalhes { get; set; }
    }

    public class DetalheProdutoDto
    {
        public int QtdEstoque { get; set; }
        public string UltimaCompra { get; set; }
        public bool Ativo { get; set; }
    }
}