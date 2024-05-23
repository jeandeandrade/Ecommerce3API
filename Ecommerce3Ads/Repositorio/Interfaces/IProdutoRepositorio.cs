using Ecommerce3Ads.Models;

namespace Ecommerce3Ads.Repositorio.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<Produto>> SearchAllProduto();
        Task<Produto> SearchPerId(int id);
        Task<Produto> AddProduto(Produto produto);
        Task<Produto> UpdateProduto(Produto produto, int id);
        Task<bool> DeleteProduto(int id);
    }
}
