using Adapters.Controllers;
using Adapters.Gateways.Interfaces;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Application.Test.Adapters.Controllers
{
    [TestClass]
    public class CategoriaControllerTests
    {
        private Mock<ICategoriaGateway> _mockCategoriaGateway;
        private CategoriaController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockCategoriaGateway = new Mock<ICategoriaGateway>();
            _controller = new CategoriaController(_mockCategoriaGateway.Object);
        }

        [TestMethod]
        public async Task ListarTodos_DeveRetornarListaDeCategorias()
        {
            // Arrange
            var categoriasEsperadas = new List<Categoria>
            {
                new Categoria { IdCategoria = 1, Nome = "Lanches" },
                new Categoria { IdCategoria = 2, Nome = "Bebidas" },
                new Categoria { IdCategoria = 3, Nome = "Sobremesas" }
            };

            _mockCategoriaGateway
                .Setup(x => x.ListarTodasCategorias())
                .ReturnsAsync(categoriasEsperadas);

            // Act
            var resultado = await _controller.ListarTodos();

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(3, resultado.Count);
            Assert.AreEqual("Lanches", resultado[0].Nome);
            _mockCategoriaGateway.Verify(x => x.ListarTodasCategorias(), Times.Once);
        }

        [TestMethod]
        public async Task ListarTodos_ComListaVazia_DeveRetornarListaVazia()
        {
            // Arrange
            _mockCategoriaGateway
                .Setup(x => x.ListarTodasCategorias())
                .ReturnsAsync(new List<Categoria>());

            // Act
            var resultado = await _controller.ListarTodos();

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(0, resultado.Count);
            _mockCategoriaGateway.Verify(x => x.ListarTodasCategorias(), Times.Once);
        }

        [TestMethod]
        public void CategoriaController_DeveSerInstanciadoComDependencias()
        {
            // Arrange & Act
            var controller = new CategoriaController(_mockCategoriaGateway.Object);

            // Assert
            Assert.IsNotNull(controller);
        }
    }
}
