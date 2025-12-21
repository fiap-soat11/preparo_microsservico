using Application.Configurations;
using Application.UseCases;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Test.UseCases
{
    [TestClass]
    public class ProdutoUseCaseTests
    {
        private ProdutoUseCase _produtoUseCase;

        [TestInitialize]
        public void Setup()
        {
            _produtoUseCase = new ProdutoUseCase();
        }

        [TestMethod]
        public async Task AtualizarProduto_DeveRetornarProdutoAtualizado()
        {
            // Arrange
            var produto = new Produto
            {
                IdProduto = 1,
                Nome = "Hamburguer",
                IdCategoria = 1,
                Descricao = "Hamburguer artesanal",
                Preco = 25.90m,
                Imagens = "imagem.jpg"
            };

            // Act
            var resultado = await _produtoUseCase.AtualizarProduto(produto);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(produto.IdProduto, resultado.IdProduto);
            Assert.AreEqual(produto.Nome, resultado.Nome);
            Assert.AreEqual(produto.Preco, resultado.Preco);
        }

        [TestMethod]
        public async Task BuscarProdutoPorId_DeveRetornarProdutoComIdCorreto()
        {
            // Arrange
            int idProduto = 10;

            // Act
            var resultado = await _produtoUseCase.BuscarProdutoPorId(idProduto);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(idProduto, resultado.IdProduto);
        }

        [TestMethod]
        public async Task BuscarProdutoPorId_ComIdZero_DeveRetornarProdutoComIdZero()
        {
            // Arrange
            int idProduto = 0;

            // Act
            var resultado = await _produtoUseCase.BuscarProdutoPorId(idProduto);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(0, resultado.IdProduto);
        }

        [TestMethod]
        public async Task BuscarProdutoPorCategoria_DeveRetornarListaVazia()
        {
            // Arrange
            int idCategoria = 1;

            // Act
            var resultado = await _produtoUseCase.BuscarProdutoPorCategoria(idCategoria);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsInstanceOfType(resultado, typeof(List<Produto>));
            Assert.AreEqual(0, resultado.Count);
        }

        [TestMethod]
        public async Task ListarTodos_DeveRetornarListaVazia()
        {
            // Act
            var resultado = await _produtoUseCase.ListarTodos();

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsInstanceOfType(resultado, typeof(IEnumerable<Produto>));
        }

        [TestMethod]
        public async Task RemoverProduto_ComIdValido_DeveRetornarProduto()
        {
            // Arrange
            int idProduto = 5;

            // Act
            var resultado = await _produtoUseCase.RemoverProduto(idProduto);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(idProduto, resultado.IdProduto);
        }

        [TestMethod]
        public async Task RemoverProduto_ComIdZero_DeveRetornarProduto()
        {
            // Arrange
            int idProduto = 0;

            // Act
            var resultado = await _produtoUseCase.RemoverProduto(idProduto);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(idProduto, resultado.IdProduto);
        }
    }
}
