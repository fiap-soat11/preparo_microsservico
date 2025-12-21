using Adapters.Presenters.Categoria;
using Adapters.Presenters.Produto;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Mappers;

namespace Application.Test.Adapters.Mappers
{
    [TestClass]
    public class ProdutoMapperTests
    {
        [TestMethod]
        public void ProdutoToDTO_DeveConverterSomenteId()
        {
            // Arrange
            var produto = new Produto
            {
                IdProduto = 5,
                Nome = "X-Burguer",
                IdCategoria = 1,
                Descricao = "Hamburguer com queijo",
                Preco = 18.50m,
                Imagens = "xburguer.jpg"
            };

            // Act
            var resultado = ProdutoMapper.ProdutoToDTO(produto);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(5, resultado.IdProduto);
            Assert.IsInstanceOfType(resultado, typeof(ProdutoResponse));
        }

        [TestMethod]
        public void ToDTO_DeveConverterTodasPropriedades()
        {
            // Arrange
            var produto = new Produto
            {
                IdProduto = 10,
                Nome = "Coca-Cola",
                IdCategoria = 2,
                Descricao = "Refrigerante 350ml",
                Preco = 5.00m,
                Imagens = "coca.jpg"
            };

            // Act
            var resultado = ProdutoMapper.ToDTO(produto);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(10, resultado.IdProduto);
            Assert.AreEqual("Coca-Cola", resultado.Nome);
            Assert.AreEqual(2, resultado.IdCategoria);
            Assert.AreEqual("Refrigerante 350ml", resultado.Descricao);
            Assert.AreEqual(5.00m, resultado.Preco);
            Assert.AreEqual("coca.jpg", resultado.Imagem);
        }

        [TestMethod]
        public void ToEntity_DeveConverterRequestParaEntity()
        {
            // Arrange
            var produtoRequest = new ProdutoRequest
            {
                IdProduto = 15,
                Nome = "McFlurry",
                IdCategoria = 3,
                Descricao = "Sorvete com Oreo",
                Preco = 12.90m,
                Imagens = "mcflurry.jpg"
            };

            // Act
            var resultado = ProdutoMapper.ToEntity(produtoRequest);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(15, resultado.IdProduto);
            Assert.AreEqual("McFlurry", resultado.Nome);
            Assert.AreEqual(3, resultado.IdCategoria);
            Assert.AreEqual("Sorvete com Oreo", resultado.Descricao);
            Assert.AreEqual(12.90m, resultado.Preco);
            Assert.AreEqual("mcflurry.jpg", resultado.Imagens);
            Assert.IsInstanceOfType(resultado, typeof(Produto));
        }

        [TestMethod]
        public void ToEntity_ComValoresNulos_DeveConverterCorretamente()
        {
            // Arrange
            var produtoRequest = new ProdutoRequest
            {
                IdProduto = 20,
                Nome = "Produto Simples",
                IdCategoria = 1,
                Descricao = null,
                Preco = 10.00m,
                Imagens = null
            };

            // Act
            var resultado = ProdutoMapper.ToEntity(produtoRequest);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(20, resultado.IdProduto);
            Assert.AreEqual("Produto Simples", resultado.Nome);
            Assert.IsNull(resultado.Descricao);
            Assert.IsNull(resultado.Imagens);
        }

        [TestMethod]
        public void ToDTO_ComValoresNulos_DeveConverterCorretamente()
        {
            // Arrange
            var produto = new Produto
            {
                IdProduto = 25,
                Nome = "Produto Básico",
                IdCategoria = 1,
                Descricao = null,
                Preco = 8.50m,
                Imagens = null
            };

            // Act
            var resultado = ProdutoMapper.ToDTO(produto);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(25, resultado.IdProduto);
            Assert.AreEqual("Produto Básico", resultado.Nome);
            Assert.IsNull(resultado.Descricao);
            Assert.IsNull(resultado.Imagem);
        }
    }
}
