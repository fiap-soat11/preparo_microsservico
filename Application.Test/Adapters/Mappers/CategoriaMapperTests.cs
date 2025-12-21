using Adapters.Presenters.Categoria;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Mappers;

namespace Application.Test.Adapters.Mappers
{
    [TestClass]
    public class CategoriaMapperTests
    {
        [TestMethod]
        public void CategoriaClienteToDTO_DeveConverterCorretamente()
        {
            // Arrange
            var categoria = new Categoria
            {
                IdCategoria = 1,
                Nome = "Lanches"
            };

            // Act
            var resultado = CategoriaMapper.CategoriaClienteToDTO(categoria);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(1, resultado.IdCategoria);
            Assert.IsInstanceOfType(resultado, typeof(CategoriaResponse));
        }

        [TestMethod]
        public void ToDTO_DeveConverterComTodasPropriedades()
        {
            // Arrange
            var categoria = new Categoria
            {
                IdCategoria = 2,
                Nome = "Bebidas"
            };

            // Act
            var resultado = CategoriaMapper.ToDTO(categoria);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.IdCategoria);
            Assert.AreEqual("Bebidas", resultado.Nome);
        }

        [TestMethod]
        public void ToDTO_ComCategoriaVazia_DeveConverterSemErros()
        {
            // Arrange
            var categoria = new Categoria
            {
                IdCategoria = 0,
                Nome = string.Empty
            };

            // Act
            var resultado = CategoriaMapper.ToDTO(categoria);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(0, resultado.IdCategoria);
            Assert.AreEqual(string.Empty, resultado.Nome);
        }
    }
}
