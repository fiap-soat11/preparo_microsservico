using Adapters.Gateways;
using Adapters.Gateways.Interfaces;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Application.Test.Adapters.Gateways
{
    [TestClass]
    public class ProdutoGatewayTests
    {
        private Mock<IDataSource> _mockDataSource;
        private ProdutoGateway _gateway;

        [TestInitialize]
        public void Setup()
        {
            _mockDataSource = new Mock<IDataSource>();
            _gateway = new ProdutoGateway(_mockDataSource.Object);
        }

        [TestMethod]
        public async Task AtualizarProduto_DeveInvocarDataSource()
        {
            // Arrange
            var produto = new Produto
            {
                IdProduto = 1,
                Nome = "Produto Atualizado",
                IdCategoria = 1,
                Preco = 25.00m
            };

            _mockDataSource
                .Setup(x => x.AtualizarProduto(produto))
                .Returns(Task.CompletedTask);

            // Act
            await _gateway.AtualizarProduto(produto);

            // Assert
            _mockDataSource.Verify(x => x.AtualizarProduto(produto), Times.Once);
        }

        [TestMethod]
        public async Task BuscarProdutosCategoria_DeveRetornarProdutosPorCategoria()
        {
            // Arrange
            int idCategoria = 1;
            var produtosEsperados = new List<Produto>
            {
                new Produto { IdProduto = 1, Nome = "Produto 1", IdCategoria = 1 },
                new Produto { IdProduto = 2, Nome = "Produto 2", IdCategoria = 1 }
            };

            _mockDataSource
                .Setup(x => x.BuscarProdutosCategoria(idCategoria))
                .ReturnsAsync(produtosEsperados);

            // Act
            var resultado = await _gateway.BuscarProdutosCategoria(idCategoria);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count);
            _mockDataSource.Verify(x => x.BuscarProdutosCategoria(idCategoria), Times.Once);
        }

        [TestMethod]
        public async Task ExcluirProduto_DeveInvocarDataSource()
        {
            // Arrange
            var produto = new Produto { IdProduto = 1, Nome = "Produto a excluir" };

            _mockDataSource
                .Setup(x => x.ExcluirProduto(produto))
                .Returns(Task.CompletedTask);

            // Act
            await _gateway.ExcluirProduto(produto);

            // Assert
            _mockDataSource.Verify(x => x.ExcluirProduto(produto), Times.Once);
        }

        [TestMethod]
        public async Task IncluirProduto_DeveInvocarDataSource()
        {
            // Arrange
            var produto = new Produto
            {
                Nome = "Novo Produto",
                IdCategoria = 1,
                Preco = 15.00m
            };

            _mockDataSource
                .Setup(x => x.IncluirProduto(produto))
                .ReturnsAsync(produto);

            // Act
            await _gateway.IncluirProduto(produto);

            // Assert
            _mockDataSource.Verify(x => x.IncluirProduto(produto), Times.Once);
        }

        [TestMethod]
        public async Task ListarProdutos_DeveRetornarTodosProdutos()
        {
            // Arrange
            var produtosEsperados = new List<Produto>
            {
                new Produto { IdProduto = 1, Nome = "Produto 1" },
                new Produto { IdProduto = 2, Nome = "Produto 2" },
                new Produto { IdProduto = 3, Nome = "Produto 3" }
            };

            _mockDataSource
                .Setup(x => x.ListarProdutos())
                .ReturnsAsync(produtosEsperados);

            // Act
            var resultado = await _gateway.ListarProdutos();

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(3, resultado.Count());
            _mockDataSource.Verify(x => x.ListarProdutos(), Times.Once);
        }

        [TestMethod]
        public async Task BuscarProdutoPorId_DeveRetornarProdutoCorreto()
        {
            // Arrange
            int idProduto = 1;
            var produtoEsperado = new Produto
            {
                IdProduto = idProduto,
                Nome = "Produto Específico",
                Preco = 30.00m
            };

            _mockDataSource
                .Setup(x => x.BuscarProdutoPorProdutoID(idProduto))
                .ReturnsAsync(produtoEsperado);

            // Act
            var resultado = await _gateway.BuscarProdutoPorId(idProduto);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(idProduto, resultado.IdProduto);
            Assert.AreEqual("Produto Específico", resultado.Nome);
            _mockDataSource.Verify(x => x.BuscarProdutoPorProdutoID(idProduto), Times.Once);
        }

        [TestMethod]
        public void ProdutoGateway_DeveSerInstanciadoComDependencias()
        {
            // Arrange & Act
            var gateway = new ProdutoGateway(_mockDataSource.Object);

            // Assert
            Assert.IsNotNull(gateway);
        }
    }
}
