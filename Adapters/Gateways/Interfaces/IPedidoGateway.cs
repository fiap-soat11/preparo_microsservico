using Domain;

namespace Adapters.Gateways.Interfaces
{
    public interface IPedidoGateway
    {
        Task CancelarPedido(int idPedido);
        Task FinalizarPedido(int idPedido);
        Task AtualizarStatusPedido(int idStatusPedido, int idPedido);

    }
}
