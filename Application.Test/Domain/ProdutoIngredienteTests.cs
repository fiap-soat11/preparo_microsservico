using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Test.Domain
{
    [TestClass]
    public class ProdutoIngredienteTests
    {
        [TestMethod]
        public void ProdutoIngrediente_DeveInstanciarCorretamente()
        {
            // Act
            var produtoIngrediente = new ProdutoIngrediente();

            // Assert
            Assert.IsNotNull(produtoIngrediente);
            Assert.AreEqual(0, produtoIngrediente.IdProdutoIngrediente);
            Assert.AreEqual(0, produtoIngrediente.IdProduto);
            Assert.AreEqual(0, produtoIngrediente.IdIngrediente);
            Assert.AreEqual(0, produtoIngrediente.Quantidade);
        }

        [TestMethod]
        public void ProdutoIngrediente_DeveDefinirPropriedadesCorretamente()
        {
            // Arrange
            var produtoIngrediente = new ProdutoIngrediente
            {
                IdProdutoIngrediente = 1,
                IdProduto = 10,
                IdIngrediente = 5,
                Quantidade = 150.5m
            };

            // Assert
            Assert.AreEqual(1, produtoIngrediente.IdProdutoIngrediente);
            Assert.AreEqual(10, produtoIngrediente.IdProduto);
            Assert.AreEqual(5, produtoIngrediente.IdIngrediente);
            Assert.AreEqual(150.5m, produtoIngrediente.Quantidade);
        }

        [TestMethod]
        public void ProdutoIngrediente_DevePermitirNavegacao()
        {
            // Arrange
            var produto = new Produto { IdProduto = 1, Nome = "Hamburguer" };
            var ingrediente = new Ingrediente { IdIngrediente = 1, Nome = "Carne", UnidadeMedida = "g" };

            var produtoIngrediente = new ProdutoIngrediente
            {
                IdProdutoIngrediente = 1,
                IdProduto = 1,
                IdIngrediente = 1,
                Quantidade = 200,
                IdProdutoNavigation = produto,
                IdIngredienteNavigation = ingrediente
            };

            // Assert
            Assert.IsNotNull(produtoIngrediente.IdProdutoNavigation);
            Assert.IsNotNull(produtoIngrediente.IdIngredienteNavigation);
            Assert.AreEqual("Hamburguer", produtoIngrediente.IdProdutoNavigation.Nome);
            Assert.AreEqual("Carne", produtoIngrediente.IdIngredienteNavigation.Nome);
        }

        [TestMethod]
        public void ProdutoIngrediente_DevePermitirQuantidadeDecimal()
        {
            // Arrange
            var produtoIngrediente = new ProdutoIngrediente
            {
                Quantidade = 0.25m
            };

            // Assert
            Assert.AreEqual(0.25m, produtoIngrediente.Quantidade);
        }
    }
}
