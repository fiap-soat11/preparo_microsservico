using Adapters.Presenters.Produto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Test.Adapters.Presenters
{
    [TestClass]
    public class ProdutoRequestTests
    {
        [TestMethod]
        public void ProdutoRequest_DeveInstanciarCorretamente()
        {
            // Act
            var request = new ProdutoRequest();

            // Assert
            Assert.IsNotNull(request);
            Assert.AreEqual(0, request.IdProduto);
        }

        [TestMethod]
        public void ProdutoRequest_DeveDefinirTodasPropriedades()
        {
            // Arrange
            var request = new ProdutoRequest
            {
                IdProduto = 1,
                Nome = "X-Burguer",
                IdCategoria = 1,
                Descricao = "Hamburguer com queijo",
                Preco = 18.50m,
                Imagens = "xburguer.jpg"
            };

            // Assert
            Assert.AreEqual(1, request.IdProduto);
            Assert.AreEqual("X-Burguer", request.Nome);
            Assert.AreEqual(1, request.IdCategoria);
            Assert.AreEqual("Hamburguer com queijo", request.Descricao);
            Assert.AreEqual(18.50m, request.Preco);
            Assert.AreEqual("xburguer.jpg", request.Imagens);
        }

        [TestMethod]
        public void ProdutoRequest_DevePermitirValoresNulos()
        {
            // Arrange
            var request = new ProdutoRequest
            {
                Nome = "Produto Simples",
                IdCategoria = 1,
                Preco = 10.00m,
                Descricao = null,
                Imagens = null
            };

            // Assert
            Assert.IsNull(request.Descricao);
            Assert.IsNull(request.Imagens);
        }
    }
}
