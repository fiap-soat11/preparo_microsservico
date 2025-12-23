using Application.Configurations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Test.Configurations
{
    [TestClass]
    public class BusinessExceptionTests
    {
        [TestMethod]
        public void BusinessException_DeveSerInstanciadaComMensagem()
        {
            // Arrange
            string mensagemEsperada = "Erro de negócio";

            // Act
            var exception = new BusinessException(mensagemEsperada);

            // Assert
            Assert.IsNotNull(exception);
            Assert.AreEqual(mensagemEsperada, exception.Message);
            Assert.IsInstanceOfType(exception, typeof(Exception));
        }

        [TestMethod]
        public void BusinessException_DeveTerMensagemNula()
        {
            // Act
            var exception = new BusinessException(null);

            // Assert
            Assert.IsNotNull(exception);
            // BusinessException com mensagem null é válida
        }

        [TestMethod]
        public void BusinessException_DeveSerLancada()
        {
            // Arrange
            string mensagem = "Operação inválida";

            // Act & Assert
            var exception = Assert.ThrowsException<BusinessException>(() =>
            {
                throw new BusinessException(mensagem);
            });

            Assert.AreEqual(mensagem, exception.Message);
        }
    }
}
