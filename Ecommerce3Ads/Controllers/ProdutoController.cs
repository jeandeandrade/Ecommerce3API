using Ecommerce3Ads.Models;
using Ecommerce3Ads.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce3Ads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> ListAllProduto()
        {
            List<Produto> produtos = await _produtoRepositorio.SearchAllProduto();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> SearchPerId(int id)
        {
            Produto produto = await _produtoRepositorio.SearchPerId(id);
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Cadastrar([FromBody] Produto produtoModels)
        {
            Produto produtos = await _produtoRepositorio.AddProduto(produtoModels);
            return Ok(produtos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> Atualizar([FromBody] Produto produtoModels, int id)
        {
            produtoModels.Id = id;
            Produto produto = await _produtoRepositorio.UpdateProduto(produtoModels, id);
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Apagar(int id)
        {
            bool apagado = await _produtoRepositorio.DeleteProduto(id);
            return Ok(apagado);
        }
    }
}
