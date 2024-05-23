using Ecommerce3Ads.Data;
using Ecommerce3Ads.Models;
using Ecommerce3Ads.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce3Ads.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly EcommerceDBContext _dbContext;

        public ProdutoRepositorio(EcommerceDBContext ecommerceDBContext)
        {
            _dbContext = ecommerceDBContext;
        }

        public async Task<Produto> SearchPerId(int id)
        {
            return await _dbContext.Produto
                .Include(x => x.Categoria)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Produto>> SearchAllProduto()
        {
            return await _dbContext.Produto
                .Include(x => x.Categoria)
                .ToListAsync();
        }

        public async Task<Produto> AddProduto(Produto produto)
        {
            await _dbContext.Produto.AddAsync(produto);
            await _dbContext.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> UpdateProduto(Produto produto, int id)
        {

            Produto produtoPerId = await SearchPerId(id);

            if (produtoPerId == null)
            {
                throw new Exception($"Produto para o ID: {id} não foi encontrado no banco de dados.");
            }

            produtoPerId.Nome = produto.Nome;
            produtoPerId.CategoriaId = produto.CategoriaId;

            _dbContext.Produto.Update(produtoPerId);
            await _dbContext.SaveChangesAsync();

            return produtoPerId;
        }

        public async Task<bool> DeleteProduto(int id)
        {
            Produto produtoPerId = await SearchPerId(id);

            if (produtoPerId == null)
            {
                throw new Exception($"Produto para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Produto.Remove(produtoPerId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
