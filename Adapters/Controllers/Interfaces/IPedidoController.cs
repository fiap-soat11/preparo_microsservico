using Domain;
using Adapters.Presenters.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.Controllers.Interfaces
{
    public interface IPedidoController
    {
        Task AtualizarStatusPedido(int idStatusPedido, int idPedido);
        Task FinalizarPedido(int pedido);
        Task CancelarPedido(int pedido);        
    }
}
