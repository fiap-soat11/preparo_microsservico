using System.Threading.Tasks;
using Xunit;
using Application.UseCases;

namespace Application.Test
{
    public class PedidoUseCaseTests
    {
        [Fact]
        public async Task ListarStatus_ReturnsEmptyEnumerable()
        {
            var useCase = new PedidoUseCase();

            var result = await useCase.ListarStatus();

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task AtualizarStatusPedido_CompletesWithoutThrowing()
        {
            var useCase = new PedidoUseCase();

            // Should not throw
            await useCase.AtualizarStatusPedido(1, 2);

            Assert.True(true);
        }
    }
}
