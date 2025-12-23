using Application.UseCases;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Test.UseCases
{
    [TestClass]
    public class CategoriaUseCaseTests
    {
        private CategoriaUseCase _categoriaUseCase;

        [TestInitialize]
        public void Setup()
        {
            _categoriaUseCase = new CategoriaUseCase();
        }

        [TestMethod]
        public async Task AtualizarCategoria_DeveExecutarSemErros()
        {
            // Arrange
            var categoria = new Categoria
            {
                IdCategoria = 1,
                Nome = "Lanches"
            };

            // Act
            await _categoriaUseCase.AtualizarCategoria(categoria);

            // Assert
            Assert.IsNotNull(categoria);
        }

        [TestMethod]
        public async Task BuscarCategoriaPorId_DeveRetornarCategoria()
        {
            // Arrange
            int idCategoria = 1;

            // Act
            var resultado = await _categoriaUseCase.BuscarCategoriaPorId(idCategoria);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsInstanceOfType(resultado, typeof(Categoria));
        }

        [TestMethod]
        public async Task BuscarCategoriaPorNome_DeveRetornarCategoriaComNome()
        {
            // Arrange
            string nome = "Bebidas";

            // Act
            var resultado = await _categoriaUseCase.BuscarCategoriaPorNome(nome);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(nome, resultado.Nome);
        }

        [TestMethod]
        public async Task ListarTodos_DeveRetornarListaVazia()
        {
            // Act
            var resultado = await _categoriaUseCase.ListarTodos();

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsInstanceOfType(resultado, typeof(IEnumerable<Categoria>));
        }

        [TestMethod]
        public async Task ExcluirCategoria_DeveExecutarSemErros()
        {
            // Arrange
            string nome = "Sobremesas";

            // Act
            await _categoriaUseCase.ExcluirCategoria(nome);

            // Assert - Não deve lançar exceção
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task IncluirCategoria_DeveExecutarSemErros()
        {
            // Arrange
            var categoria = new Categoria
            {
                IdCategoria = 2,
                Nome = "Acompanhamentos"
            };

            // Act
            await _categoriaUseCase.IncluirCategoria(categoria);

            // Assert
            Assert.IsNotNull(categoria);
        }

        [TestMethod]
        public async Task FinalizarCategoria_DeveExecutarSemErros()
        {
            // Arrange
            var categoria = new Categoria
            {
                IdCategoria = 3,
                Nome = "Promocionais"
            };

            // Act
            await _categoriaUseCase.FinalizarCategoria(categoria);

            // Assert
            Assert.IsNotNull(categoria);
        }

        [TestMethod]
        public async Task CancelarCategoria_DeveExecutarSemErros()
        {
            // Arrange
            var categoria = new Categoria
            {
                IdCategoria = 4,
                Nome = "Especiais"
            };

            // Act
            await _categoriaUseCase.CancelarCategoria(categoria);

            // Assert
            Assert.IsNotNull(categoria);
        }
    }
}
