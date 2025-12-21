using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Test.Domain
{
    [TestClass]
    public class IngredienteTests
    {
        [TestMethod]
        public void Ingrediente_DeveInstanciarCorretamente()
        {
            // Act
            var ingrediente = new Ingrediente();

            // Assert
            Assert.IsNotNull(ingrediente);
            Assert.AreEqual(0, ingrediente.IdIngrediente);
            Assert.IsNotNull(ingrediente.ProdutoIngredientes);
        }

        [TestMethod]
        public void Ingrediente_DeveDefinirPropriedadesCorretamente()
        {
            // Arrange
            var ingrediente = new Ingrediente
            {
                IdIngrediente = 1,
                Nome = "Queijo Mussarela",
                Descricao = "Queijo mussarela fatiado",
                UnidadeMedida = "kg",
                PrecoUnitario = 35.00m,
                QuantidadeEmEstoque = 10.5m,
                EstoqueMinimo = 2.0m
            };

            // Assert
            Assert.AreEqual(1, ingrediente.IdIngrediente);
            Assert.AreEqual("Queijo Mussarela", ingrediente.Nome);
            Assert.AreEqual("Queijo mussarela fatiado", ingrediente.Descricao);
            Assert.AreEqual("kg", ingrediente.UnidadeMedida);
            Assert.AreEqual(35.00m, ingrediente.PrecoUnitario);
            Assert.AreEqual(10.5m, ingrediente.QuantidadeEmEstoque);
            Assert.AreEqual(2.0m, ingrediente.EstoqueMinimo);
        }

        [TestMethod]
        public void Ingrediente_DevePermitirValoresNulos()
        {
            // Arrange
            var ingrediente = new Ingrediente
            {
                Nome = "Tomate",
                UnidadeMedida = "kg",
                Descricao = null,
                PrecoUnitario = null,
                QuantidadeEmEstoque = null,
                EstoqueMinimo = null
            };

            // Assert
            Assert.IsNull(ingrediente.Descricao);
            Assert.IsNull(ingrediente.PrecoUnitario);
            Assert.IsNull(ingrediente.QuantidadeEmEstoque);
            Assert.IsNull(ingrediente.EstoqueMinimo);
        }

        [TestMethod]
        public void Ingrediente_DeveInicializarProdutoIngredientesComoListaVazia()
        {
            // Act
            var ingrediente = new Ingrediente();

            // Assert
            Assert.IsNotNull(ingrediente.ProdutoIngredientes);
            Assert.AreEqual(0, ingrediente.ProdutoIngredientes.Count);
        }
    }
}
