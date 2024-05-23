using Ecommerce3Ads.Models;

namespace Ecommerce3Ads.Repositorio.Interfaces
{
    public interface IPedidoRepositorio
    {
        Task<List<Pedido>> SearchAllPedido();
        Task<Pedido> SearchPerId(int id);
        Task<Pedido> AddPedido(Pedido pedido);
        Task<Pedido> UpdatePedido(Pedido pedido, int id);
        Task<bool> DeletePedido(int id);
    }
}
