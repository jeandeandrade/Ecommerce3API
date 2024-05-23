using Ecommerce3Ads.Models;

namespace Ecommerce3Ads.Repositorio.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> SearchAllCategoria();
        Task<Categoria> SearchPerId(int id);
        Task<Categoria> AddCategoria(Categoria categoria);
        Task<Categoria> UpdateCategoria(Categoria categoria, int id);
        Task<bool> DeleteCategoria(int id);
    }
}
