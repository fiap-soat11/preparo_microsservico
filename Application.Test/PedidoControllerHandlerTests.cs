using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Adapters.Controllers.Interfaces;
using WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Adapters.Presenters.DTOs;

namespace Application.Test
{
    public class PedidoControllerHandlerTests
    {
        [Fact]
        public async Task AtualizarStatusPedido_ReturnsOk_WhenControllerSucceeds()
        {
            var pedidoControllerMock = new Mock<IPedidoController>();
            pedidoControllerMock.Setup(p => p.AtualizarStatusPedido(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.CompletedTask);

            var loggerMock = new Mock<ILogger<PedidoControllerHandler>>();

            var handler = new PedidoControllerHandler(loggerMock.Object, pedidoControllerMock.Object);

            var request = new PedidoRequest { StatusId = 5 };

            var result = await handler.AtualizarStatusPedido(10, request);

            var ok = Assert.IsType<OkObjectResult>(result);
            Assert.Contains("atualizado", ok.Value.ToString(), StringComparison.OrdinalIgnoreCase);
            pedidoControllerMock.Verify(p => p.AtualizarStatusPedido(5, 10), Times.Once);
        }

        [Fact]
        public async Task AtualizarStatusPedido_ReturnsBadRequest_WhenControllerThrows()
        {
            var pedidoControllerMock = new Mock<IPedidoController>();
            pedidoControllerMock.Setup(p => p.AtualizarStatusPedido(It.IsAny<int>(), It.IsAny<int>())).ThrowsAsync(new Exception("boom"));

            var loggerMock = new Mock<ILogger<PedidoControllerHandler>>();

            var handler = new PedidoControllerHandler(loggerMock.Object, pedidoControllerMock.Object);

            var request = new PedidoRequest { StatusId = 3 };

            var result = await handler.AtualizarStatusPedido(7, request);

            var bad = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Contains("Erro", bad.Value.ToString(), StringComparison.OrdinalIgnoreCase);
            pedidoControllerMock.Verify(p => p.AtualizarStatusPedido(3, 7), Times.Once);
        }
    }
}
