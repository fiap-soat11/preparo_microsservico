using Adapters.Presenters.Categoria;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Test.Adapters.Presenters
{
    [TestClass]
    public class ProdutoResponseTests
    {
        [TestMethod]
        public void ProdutoResponse_DeveInstanciarCorretamente()
        {
            // Act
            var response = new ProdutoResponse();

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(0, response.IdProduto);
            Assert.AreEqual(0, response.IdCategoria);
        }

        [TestMethod]
        public void ProdutoResponse_DeveDefinirTodasPropriedades()
        {
            // Arrange
            var response = new ProdutoResponse
            {
                IdProduto = 1,
                IdCategoria = 1,
                Nome = "X-Bacon",
                Descricao = "Hamburguer com bacon",
                Preco = 21.00m,
                Imagem = "xbacon.jpg"
            };

            // Assert
            Assert.AreEqual(1, response.IdProduto);
            Assert.AreEqual(1, response.IdCategoria);
            Assert.AreEqual("X-Bacon", response.Nome);
            Assert.AreEqual("Hamburguer com bacon", response.Descricao);
            Assert.AreEqual(21.00m, response.Preco);
            Assert.AreEqual("xbacon.jpg", response.Imagem);
        }

        [TestMethod]
        public void ProdutoResponse_DevePermitirValoresNulos()
        {
            // Arrange
            var response = new ProdutoResponse
            {
                IdProduto = 2,
                Nome = "Produto Básico",
                IdCategoria = 1,
                Preco = 15.00m,
                Descricao = null,
                Imagem = null
            };

            // Assert
            Assert.IsNull(response.Descricao);
            Assert.IsNull(response.Imagem);
        }
    }
}
