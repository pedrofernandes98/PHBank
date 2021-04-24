using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHBank;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        //[ExpectedException(typeof(FileNotFoundException), "Exceção não foi lançada!")]
        public void UsarRecursosExternosExplicitoTests()
        {
            #region Arrange
            
            #endregion

            #region Act
            PHBank.Program.UsarRecursosExternosExplicito();
            #endregion

            #region Assert
            
            #endregion
        }
    }
}