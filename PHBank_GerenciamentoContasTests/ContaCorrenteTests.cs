using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;

namespace PHBank_GerenciamentoContas.Tests
{
    [TestClass()]
    public class ContaCorrenteTests
    {
        [TestMethod()]
        public void SacarSuccesTest()
        {
            #region Arrange
            ContaCorrente contaCorrente = new ContaCorrente(1234, 123456789);
            bool sucess = false;
            contaCorrente.Depositar(1000);
            #endregion

            #region Act
            sucess = contaCorrente.Sacar(100);
            #endregion

            #region Assert
            Assert.IsTrue(sucess);
            #endregion
        }

        [TestMethod()]
        public void SacarFailTest()
        {
            #region Arrange
            ContaCorrente contaCorrente = new ContaCorrente(1234, 123456789);
            bool sucess = false;
            contaCorrente.Depositar(1000);
            #endregion

            #region Act
            sucess = contaCorrente.Sacar(10000);
            #endregion

            #region Assert
            Assert.IsFalse(sucess);
            #endregion
        }

        [TestMethod()]
        public void SacarInvalidValueTest()
        {
            #region Arrange
            ContaCorrente contaCorrente = new ContaCorrente(1234, 123456789);
            bool sucess = false;
            contaCorrente.Depositar(1000);
            #endregion

            #region Act
            sucess = contaCorrente.Sacar(-40);
            #endregion

            #region Assert
            Assert.IsFalse(sucess);
            #endregion
        }
    }
}