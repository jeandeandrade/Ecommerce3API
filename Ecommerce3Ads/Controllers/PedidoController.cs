using Ecommerce3Ads.Models;
using Ecommerce3Ads.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce3Ads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidoController(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> ListAllTasks()
        {
            List<Pedido> pedidos = await _pedidoRepositorio.SearchAllPedido();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> SearchPerId(int id)
        {
            Pedido pedido = await _pedidoRepositorio.SearchPerId(id);
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> Cadastrar([FromBody] Pedido pedidoModels)
        {
            Pedido pedidos = await _pedidoRepositorio.AddPedido(pedidoModels);
            return Ok(pedidos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pedido>> Atualizar([FromBody] Pedido pedidoModels, int id)
        {
            pedidoModels.Id = id;
            Pedido pedido = await _pedidoRepositorio.UpdatePedido(pedidoModels, id);
            return Ok(pedido);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedido>> Apagar(int id)
        {
            bool apagado = await _pedidoRepositorio.DeletePedido(id);
            return Ok(apagado);
        }
    }
}
