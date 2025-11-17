using Application.Interfaces;
using Domain;
using Application.Configurations;

namespace Application.UseCases
{
    public class PedidoUseCase : IPedidoUseCase
    {        
        public async Task<IEnumerable<Status>> ListarStatus()
        {
            //return _statusRepository.ListarTodos();
            return new List<Status>();
        }

        public async Task AtualizarStatusPedido(int idPedido, int novoStatusId)
        {
            return;
        }
    }
}
