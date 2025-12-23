using Adapters.Gateways;
using Adapters.Gateways.Interfaces;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Application.Test.Adapters.Gateways
{
    [TestClass]
    public class CategoriaGatewayTests
    {
        private Mock<IDataSource> _mockDataSource;
        private CategoriaGateway _gateway;

        [TestInitialize]
        public void Setup()
        {
            _mockDataSource = new Mock<IDataSource>();
            _gateway = new CategoriaGateway(_mockDataSource.Object);
        }

        [TestMethod]
        public async Task ListarTodasCategorias_DeveRetornarCategorias()
        {
            // Arrange
            var categoriasEsperadas = new List<Categoria>
            {
                new Categoria { IdCategoria = 1, Nome = "Lanches" },
                new Categoria { IdCategoria = 2, Nome = "Bebidas" }
            };

            _mockDataSource
                .Setup(x => x.ListarCategorias())
                .ReturnsAsync(categoriasEsperadas);

            // Act
            var resultado = await _gateway.ListarTodasCategorias();

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count());
            _mockDataSource.Verify(x => x.ListarCategorias(), Times.Once);
        }

        [TestMethod]
        public async Task BuscarCategoriaPorId_ComIdExistente_DeveRetornarCategoria()
        {
            // Arrange
            int idCategoria = 1;
            var categorias = new List<Categoria>
            {
                new Categoria { IdCategoria = 1, Nome = "Lanches" },
                new Categoria { IdCategoria = 2, Nome = "Bebidas" }
            };

            _mockDataSource
                .Setup(x => x.ListarCategorias())
                .ReturnsAsync(categorias);

            // Act
            var resultado = await _gateway.BuscarCategoriaPorId(idCategoria);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(idCategoria, resultado.IdCategoria);
            Assert.AreEqual("Lanches", resultado.Nome);
        }

        [TestMethod]
        public async Task BuscarCategoriaPorId_ComIdInexistente_DeveRetornarNull()
        {
            // Arrange
            int idCategoria = 999;
            var categorias = new List<Categoria>
            {
                new Categoria { IdCategoria = 1, Nome = "Lanches" }
            };

            _mockDataSource
                .Setup(x => x.ListarCategorias())
                .ReturnsAsync(categorias);

            // Act
            var resultado = await _gateway.BuscarCategoriaPorId(idCategoria);

            // Assert
            Assert.IsNull(resultado);
        }

        [TestMethod]
        public void CategoriaGateway_DeveSerInstanciadoComDependencias()
        {
            // Arrange & Act
            var gateway = new CategoriaGateway(_mockDataSource.Object);

            // Assert
            Assert.IsNotNull(gateway);
        }
    }
}
