using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Test.Domain
{
    [TestClass]
    public class ProdutoTests
    {
        [TestMethod]
        public void Produto_DeveInstanciarCorretamente()
        {
            // Act
            var produto = new Produto();

            // Assert
            Assert.IsNotNull(produto);
            Assert.AreEqual(0, produto.IdProduto);
            Assert.IsNotNull(produto.ProdutoIngredientes);
        }

        [TestMethod]
        public void Produto_DeveDefinirPropriedadesCorretamente()
        {
            // Arrange
            var produto = new Produto
            {
                IdProduto = 1,
                Nome = "X-Burguer",
                IdCategoria = 1,
                Descricao = "Hamburguer com queijo",
                Preco = 18.50m,
                Imagens = "xburguer.jpg"
            };

            // Assert
            Assert.AreEqual(1, produto.IdProduto);
            Assert.AreEqual("X-Burguer", produto.Nome);
            Assert.AreEqual(1, produto.IdCategoria);
            Assert.AreEqual("Hamburguer com queijo", produto.Descricao);
            Assert.AreEqual(18.50m, produto.Preco);
            Assert.AreEqual("xburguer.jpg", produto.Imagens);
        }

        [TestMethod]
        public void Produto_DeveInicializarProdutoIngredientesComoListaVazia()
        {
            // Act
            var produto = new Produto();

            // Assert
            Assert.IsNotNull(produto.ProdutoIngredientes);
            Assert.AreEqual(0, produto.ProdutoIngredientes.Count);
        }

        [TestMethod]
        public void Produto_DevePermitirAdicionarIngredientes()
        {
            // Arrange
            var produto = new Produto
            {
                IdProduto = 1,
                Nome = "Pizza"
            };

            var produtoIngrediente = new ProdutoIngrediente
            {
                IdProdutoIngrediente = 1,
                IdProduto = 1,
                IdIngrediente = 1,
                Quantidade = 100
            };

            // Act
            produto.ProdutoIngredientes.Add(produtoIngrediente);

            // Assert
            Assert.AreEqual(1, produto.ProdutoIngredientes.Count);
            Assert.AreEqual(produtoIngrediente, produto.ProdutoIngredientes.First());
        }

        [TestMethod]
        public void Produto_DevePermitirPrecoDecimal()
        {
            // Arrange
            var produto = new Produto
            {
                Preco = 12.99m
            };

            // Assert
            Assert.AreEqual(12.99m, produto.Preco);
        }
    }
}
