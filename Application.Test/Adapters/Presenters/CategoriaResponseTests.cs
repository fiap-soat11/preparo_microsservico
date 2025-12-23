using Adapters.Presenters.Categoria;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Test.Adapters.Presenters
{
    [TestClass]
    public class CategoriaResponseTests
    {
        [TestMethod]
        public void CategoriaResponse_DeveInstanciarCorretamente()
        {
            // Act
            var response = new CategoriaResponse();

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(0, response.IdCategoria);
            Assert.IsNotNull(response.Produtos);
        }

        [TestMethod]
        public void CategoriaResponse_DeveDefinirPropriedadesCorretamente()
        {
            // Arrange
            var response = new CategoriaResponse
            {
                IdCategoria = 1,
                Nome = "Lanches"
            };

            // Assert
            Assert.AreEqual(1, response.IdCategoria);
            Assert.AreEqual("Lanches", response.Nome);
        }

        [TestMethod]
        public void CategoriaResponse_DevePermitirAdicionarProdutos()
        {
            // Arrange
            var response = new CategoriaResponse
            {
                IdCategoria = 1,
                Nome = "Bebidas"
            };

            var produto = new Produto
            {
                IdProduto = 1,
                Nome = "Coca-Cola",
                IdCategoria = 1
            };

            // Act
            response.Produtos.Add(produto);

            // Assert
            Assert.AreEqual(1, response.Produtos.Count);
            Assert.AreEqual(produto, response.Produtos.First());
        }
    }
}
