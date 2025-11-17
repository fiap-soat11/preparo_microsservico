using Adapters.Presenters.Pedido;
using Microsoft.AspNetCore.Mvc;
using Application.Configurations;
using Adapters.Controllers.Interfaces;
using WebAPI.Mappers;
using Adapters.Presenters.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PedidoControllerHandler : ControllerBase
    {
        private readonly ILogger<PedidoControllerHandler> _logger;
        private readonly IPedidoController _pedidoController;

        public PedidoControllerHandler(ILogger<PedidoControllerHandler> logger, IPedidoController pedidoController)
        {
            _logger = logger;
            _pedidoController = pedidoController;
        }

        [HttpPost("AtualizarPedido")]
        [ProducesResponseType(typeof(PedidoCozinhaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> AtualizarStatusPedido(int idPedido, PedidoRequest request)
        {
            try
            {
                await _pedidoController.AtualizarStatusPedido(request.StatusId, idPedido);
               
                return Ok("Status do pedido atualizado com sucesso"); 
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar pedido");
                return BadRequest("Erro ao atualizar pedido");
            }
           
        }

        [HttpPost("FinalizarPedido")]
        [ProducesResponseType(typeof(PedidoCozinhaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> FinalizarPedido(int idPedido)
        {
            try
            {
                await _pedidoController.FinalizarPedido(idPedido);

                return Ok("Pedido finalizado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao finalizar pedido");
                return BadRequest("Erro ao finalizar pedido");
            }

        }


        [HttpPost("CancelarPedido")]
        [ProducesResponseType(typeof(PedidoCozinhaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> CancelarPedido(int idPedido)
        {
            try
            {

                await _pedidoController.CancelarPedido(idPedido);

                return Ok("Pedido cancelado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cancelado pedido");
                return BadRequest("Erro ao cancelado pedido");
            }

        }

    }
}
