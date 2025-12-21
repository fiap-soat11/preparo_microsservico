using Adapters.Controllers;
using Adapters.Gateways.Interfaces;
using Adapters.Presenters.Produto;
using Application.Configurations;
using Domain;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Application.Test.Adapters.Controllers
{
    [TestClass]
    public class ProdutoControllerTests
    {
        private Mock<ILogger<ProdutoController>> _mockLogger;
        private Mock<IProdutoGateway> _mockProdutoGateway;
        private ProdutoController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<ProdutoController>>();
            _mockProdutoGateway = new Mock<IProdutoGateway>();
            _controller = new ProdutoController(_mockLogger.Object, _mockProdutoGateway.Object);
        }

        [TestMethod]
        public async Task BuscarProdutosPorCategoria_ComProdutosExistentes_DeveRetornarLista()
        {
            // Arrange
            int idCategoria = 1;
            var produtosEsperados = new List<Produto>
            {
                new Produto { IdProduto = 1, Nome = "X-Burguer", IdCategoria = 1, Preco = 18.50m },
                new Produto { IdProduto = 2, Nome = "X-Bacon", IdCategoria = 1, Preco = 21.00m }
            };

            _mockProdutoGateway
                .Setup(x => x.BuscarProdutosCategoria(idCategoria))
                .ReturnsAsync(produtosEsperados);

            // Act
            var resultado = await _controller.BuscarProdutosPorCategoria(idCategoria);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count);
            _mockProdutoGateway.Verify(x => x.BuscarProdutosCategoria(idCategoria), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public async Task BuscarProdutosPorCategoria_ComListaNula_DeveLancarBusinessException()
        {
            // Arrange
            int idCategoria = 1;
            _mockProdutoGateway
                .Setup(x => x.BuscarProdutosCategoria(idCategoria))
                .ReturnsAsync((List<Produto>)null);

            // Act
            await _controller.BuscarProdutosPorCategoria(idCategoria);

            // Assert - Espera-se BusinessException
        }

        [TestMethod]
        public async Task BuscarProdutoPorId_ComProdutoExistente_DeveRetornarProduto()
        {
            // Arrange
            int idProduto = 1;
            var produtoEsperado = new Produto
            {
                IdProduto = idProduto,
                Nome = "Coca-Cola",
                IdCategoria = 2,
                Preco = 5.00m
            };

            _mockProdutoGateway
                .Setup(x => x.BuscarProdutoPorId(idProduto))
                .ReturnsAsync(produtoEsperado);

            // Act
            var resultado = await _controller.BuscarProdutoPorId(idProduto);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(idProduto, resultado.IdProduto);
            Assert.AreEqual("Coca-Cola", resultado.Nome);
            _mockProdutoGateway.Verify(x => x.BuscarProdutoPorId(idProduto), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public async Task BuscarProdutoPorId_ComProdutoNaoExistente_DeveLancarBusinessException()
        {
            // Arrange
            int idProduto = 999;
            _mockProdutoGateway
                .Setup(x => x.BuscarProdutoPorId(idProduto))
                .ReturnsAsync((Produto)null);

            // Act
            await _controller.BuscarProdutoPorId(idProduto);

            // Assert - Espera-se BusinessException
        }

        [TestMethod]
        public async Task ListarTodos_DeveRetornarListaDeProdutos()
        {
            // Arrange
            var produtosEsperados = new List<Produto>
            {
                new Produto { IdProduto = 1, Nome = "Produto 1" },
                new Produto { IdProduto = 2, Nome = "Produto 2" }
            };

            _mockProdutoGateway
                .Setup(x => x.ListarProdutos())
                .ReturnsAsync(produtosEsperados);

            // Act
            var resultado = await _controller.ListarTodos();

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count());
            _mockProdutoGateway.Verify(x => x.ListarProdutos(), Times.Once);
        }

        [TestMethod]
        public async Task IncluirProduto_DeveInvocarGateway()
        {
            // Arrange
            var produtoRequest = new ProdutoRequest
            {
                IdProduto = 0,
                Nome = "Novo Produto",
                IdCategoria = 1,
                Descricao = "Descrição do produto",
                Preco = 15.00m,
                Imagens = "imagem.jpg"
            };

            _mockProdutoGateway
                .Setup(x => x.IncluirProduto(It.IsAny<Produto>()))
                .Returns(Task.CompletedTask);

            // Act
            await _controller.IncluirProduto(produtoRequest);

            // Assert
            _mockProdutoGateway.Verify(x => x.IncluirProduto(It.IsAny<Produto>()), Times.Once);
        }

        [TestMethod]
        public async Task AtualizarProduto_DeveInvocarGateway()
        {
            // Arrange
            var produtoRequest = new ProdutoRequest
            {
                IdProduto = 1,
                Nome = "Produto Atualizado",
                IdCategoria = 1,
                Descricao = "Nova descrição",
                Preco = 20.00m,
                Imagens = "nova_imagem.jpg"
            };

            _mockProdutoGateway
                .Setup(x => x.AtualizarProduto(It.IsAny<Produto>()))
                .Returns(Task.CompletedTask);

            // Act
            await _controller.AtualizarProduto(produtoRequest);

            // Assert
            _mockProdutoGateway.Verify(x => x.AtualizarProduto(It.IsAny<Produto>()), Times.Once);
        }

        [TestMethod]
        public void ProdutoController_DeveSerInstanciadoComDependencias()
        {
            // Arrange & Act
            var controller = new ProdutoController(_mockLogger.Object, _mockProdutoGateway.Object);

            // Assert
            Assert.IsNotNull(controller);
        }
    }
}
