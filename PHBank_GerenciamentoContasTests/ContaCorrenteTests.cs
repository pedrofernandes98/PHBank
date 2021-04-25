using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

        [TestMethod()]
        public void SacarExceptionValidAmountTest()
        {
            #region Arrange
            ContaCorrente contaCorrente = new ContaCorrente(1234, 123456789);
            double newAmount = 1000;
            double withdrawAmount = 800;
            double expected = newAmount - withdrawAmount;
            contaCorrente.Depositar(newAmount);
            #endregion

            #region Act
            contaCorrente.SacarException(withdrawAmount);
            newAmount = contaCorrente.Saldo;
            #endregion

            #region Assert
            Assert.AreEqual(expected, newAmount);
            #endregion
        }

        [TestMethod()]
        public void SacarExceptionLessThanZeroTest()
        {
            #region Arrange
            ContaCorrente contaCorrente = new ContaCorrente(1234, 123456789);
            double newAmount = 1000;
            double withdrawAmount = -8;
            //double expected = newAmount - withdrawAmount;
            contaCorrente.Depositar(newAmount);
            #endregion

            #region Act
            #endregion
            
            #region Assert
            Assert.ThrowsException<ArgumentException>(() => contaCorrente.SacarException(withdrawAmount)); //Através de um delegate valida se a expressão lança a excessão
            #endregion
        }

        [TestMethod()]
        public void SacarExceptionLowBalanceTest()
        {
            #region Arrange
            ContaCorrente conta = new ContaCorrente(1346, 159753);
            double depositoInicial = 1000;
            conta.Depositar(depositoInicial);
            double tentativaSaque = 2000;
            #endregion

            #region ActAndAssert
            Assert.ThrowsException<SaldoInsuficienteException>(() => conta.SacarException(tentativaSaque), "Deve lançar uma excessão personalizada SaldoInsuficienteException()");
            #endregion
        }
    }
}