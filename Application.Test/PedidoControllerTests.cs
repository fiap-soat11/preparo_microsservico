using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Adapters.Controllers;
using Adapters.Gateways.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Test
{
    public class PedidoControllerTests
    {
        [Fact]
        public async Task AtualizarStatusPedido_CallsGateway()
        {
            var gatewayMock = new Mock<IPedidoGateway>();
            gatewayMock.Setup(g => g.AtualizarStatusPedido(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.CompletedTask);

            var loggerMock = new Mock<ILogger<PedidoController>>();

            var controller = new PedidoController(loggerMock.Object, gatewayMock.Object);

            await controller.AtualizarStatusPedido(2, 42);

            gatewayMock.Verify(g => g.AtualizarStatusPedido(2, 42), Times.Once);
        }

        [Fact]
        public async Task AtualizarStatusPedido_WhenGatewayThrows_RethrowsException()
        {
            var gatewayMock = new Mock<IPedidoGateway>();
            gatewayMock.Setup(g => g.AtualizarStatusPedido(It.IsAny<int>(), It.IsAny<int>())).ThrowsAsync(new InvalidOperationException("fail"));

            var loggerMock = new Mock<ILogger<PedidoController>>();

            var controller = new PedidoController(loggerMock.Object, gatewayMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await controller.AtualizarStatusPedido(1, 10));
            gatewayMock.Verify(g => g.AtualizarStatusPedido(1, 10), Times.Once);
        }
    }
}
