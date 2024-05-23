using Ecommerce3Ads.Data;
using Ecommerce3Ads.Models;
using Ecommerce3Ads.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce3Ads.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly EcommerceDBContext _dbContext;

        public CategoriaRepositorio(EcommerceDBContext ecommerceDBContext)
        {
            _dbContext = ecommerceDBContext;
        }

        public async Task<Categoria> SearchPerId(int id)
        {
            return await _dbContext.Categoria.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Categoria>> SearchAllCategoria()
        {
            return await _dbContext.Categoria.ToListAsync();
        }

        public async Task<Categoria> AddCategoria(Categoria categoria)
        {
            await _dbContext.Categoria.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();

            return categoria;
        }

        public async Task<Categoria> UpdateCategoria(Categoria categoria, int id)
        {

            Categoria categoriaPerId = await SearchPerId(id);

            if (categoriaPerId == null)
            {
                throw new Exception($"Categoria para o ID: {id} não foi encontrado no banco de dados.");
            }

            categoriaPerId.Nome = categoria.Nome;

            _dbContext.Categoria.Update(categoriaPerId);
            await _dbContext.SaveChangesAsync();

            return categoriaPerId;
        }

        public async Task<bool> DeleteCategoria(int id)
        {
            Categoria categoriaPerId = await SearchPerId(id);

            if (categoriaPerId == null)
            {
                throw new Exception($"Categoria para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Categoria.Remove(categoriaPerId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
