using Adapters.Controllers.Interfaces;
using Adapters.Gateways.Interfaces;
using Application.Configurations;
using Domain;
using Microsoft.Extensions.Logging;

namespace Adapters.Controllers
{
    public class PedidoController : IPedidoController
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly IPedidoGateway _pedidoGateway;


        public PedidoController(ILogger<PedidoController> logger, IPedidoGateway pedidoGateway)
        {
            _logger = logger;
            _pedidoGateway = pedidoGateway;
        }

     
        public async Task AtualizarStatusPedido(int idStatusPedido, int idPedido)
        {
            try
            {
                await _pedidoGateway.AtualizarStatusPedido(idStatusPedido, idPedido);

                return;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar pedido");
                throw;
            }
        }

        public async Task CancelarPedido(int idPedido)
        {
            try
            {
                await _pedidoGateway.CancelarPedido(idPedido);

                return;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cancelar pedido");
                throw;
            }
        }

        public async Task FinalizarPedido(int idPedido)
        {
            try
            {

                await _pedidoGateway.FinalizarPedido(idPedido);

                return;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao finalizar pedido");
                throw;
            }
        }
    }
}
