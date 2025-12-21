using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Test.Domain
{
    [TestClass]
    public class CategoriaTests
    {
        [TestMethod]
        public void Categoria_DeveInstanciarCorretamente()
        {
            // Act
            var categoria = new Categoria();

            // Assert
            Assert.IsNotNull(categoria);
            Assert.AreEqual(0, categoria.IdCategoria);
            Assert.IsNotNull(categoria.Produtos);
        }

        [TestMethod]
        public void Categoria_DeveDefinirPropriedadesCorretamente()
        {
            // Arrange
            var categoria = new Categoria
            {
                IdCategoria = 1,
                Nome = "Lanches"
            };

            // Assert
            Assert.AreEqual(1, categoria.IdCategoria);
            Assert.AreEqual("Lanches", categoria.Nome);
        }

        [TestMethod]
        public void Categoria_DeveInicializarProdutosComoListaVazia()
        {
            // Act
            var categoria = new Categoria();

            // Assert
            Assert.IsNotNull(categoria.Produtos);
            Assert.AreEqual(0, categoria.Produtos.Count);
        }

        [TestMethod]
        public void Categoria_DevePermitirAdicionarProdutos()
        {
            // Arrange
            var categoria = new Categoria
            {
                IdCategoria = 1,
                Nome = "Bebidas"
            };

            var produto = new Produto
            {
                IdProduto = 1,
                Nome = "Refrigerante",
                IdCategoria = 1,
                Preco = 5.00m
            };

            // Act
            categoria.Produtos.Add(produto);

            // Assert
            Assert.AreEqual(1, categoria.Produtos.Count);
            Assert.AreEqual(produto, categoria.Produtos.First());
        }
    }
}
