using Ecommerce3Ads.Models;
using Ecommerce3Ads.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce3Ads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> ListAllCategoria()
        {
            List<Categoria> categorias = await _categoriaRepositorio.SearchAllCategoria();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> SearchPerId(int id)
        {
            Categoria categoria = await _categoriaRepositorio.SearchPerId(id);
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Cadastrar([FromBody] Categoria categoriaModels)
        {
            Categoria categorias = await _categoriaRepositorio.AddCategoria(categoriaModels);
            return Ok(categorias);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Categoria>> Atualizar([FromBody] Categoria categoriaModels, int id)
        {
            categoriaModels.Id = id;
            Categoria categoria = await _categoriaRepositorio.UpdateCategoria(categoriaModels, id);
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Apagar(int id)
        {
            bool apagado = await _categoriaRepositorio.DeleteCategoria(id);
            return Ok(apagado);
        }
    }
}
