using Domain;

namespace Application.Interfaces
{
    public interface IPedidoUseCase
    {
        Task<IEnumerable<Status>> ListarStatus();
        Task AtualizarStatusPedido(int idPedido, int novoStatusId);       

    }
}
