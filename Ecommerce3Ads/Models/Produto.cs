namespace Ecommerce3Ads.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }
    }
}
