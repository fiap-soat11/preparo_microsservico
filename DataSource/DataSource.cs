using Application.Configurations;
using DataSource.Repositories.Interfaces;
using Domain;
using System.Linq;

namespace DataSource
{
    public class DataSource : Adapters.Gateways.Interfaces.IDataSource
    {
        private readonly IStatusRepository _statusRepository;

        #region Status
        public async Task<IEnumerable<Status>> ListarTodosStatus()
        {
            return _statusRepository.ListarTodos();
        }

        public async Task<Status> BuscarStatusPorNome(string nomeStatus)
        {            
            return _statusRepository.Buscar(x => x.Nome == nomeStatus).First();            
        }

        public async Task<Status> BuscarStatusPorId(int idStatus)
        {
            return _statusRepository.BuscarPorId(idStatus);
        }
        #endregion

    }
}