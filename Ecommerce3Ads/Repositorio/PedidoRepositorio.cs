using Ecommerce3Ads.Data;
using Ecommerce3Ads.Models;
using Ecommerce3Ads.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce3Ads.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly EcommerceDBContext _dbContext;

        public PedidoRepositorio(EcommerceDBContext ecommerceDBContext)
        {
            _dbContext = ecommerceDBContext;
        }

        public async Task<Pedido> SearchPerId(int id)
        {
            return await _dbContext.Pedido.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Pedido>> SearchAllPedido()
        {
            return await _dbContext.Pedido.ToListAsync();
        }

        public async Task<Pedido> AddPedido(Pedido pedido)
        {
            await _dbContext.Pedido.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();

            return pedido;
        }

        public async Task<Pedido> UpdatePedido(Pedido pedido, int id)
        {

            Pedido pedidoPerId = await SearchPerId(id);

            if (pedidoPerId == null)
            {
                throw new Exception($"Pedido para o ID: {id} não foi encontrado no banco de dados.");
            }

            pedidoPerId.Quantidade = pedido.Quantidade;
            pedidoPerId.ProdutoId = pedido.ProdutoId;

            _dbContext.Pedido.Update(pedidoPerId);
            await _dbContext.SaveChangesAsync();

            return pedidoPerId;
        }

        public async Task<bool> DeletePedido(int id)
        {
            Pedido pedidoPerId = await SearchPerId(id);

            if (pedidoPerId == null)
            {
                throw new Exception($"Pedido para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Pedido.Remove(pedidoPerId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
