using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Core.Operations;
using NUnit.Framework;

namespace Calculator.Core.Test
{
    public  class OperationTest
    {
        [Test]
        public void Addition_Success()
        {
            //Arrange
            var Operation = new Addition();

            //Act
            var result = Operation.Caculate(10, 2);

            //Assert
            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void Soustration_Success()
        {
            //Arrange
            var Operation = new Soustraction();

            //Act
            var result = Operation.Caculate(4, 2);

            //Assert
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Multiplication_Success()
        {
            //Arrange
            var Operation = new Multiplication();

            //Act
            var result = Operation.Caculate(5, 4);

            //Assert
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void Division_Success()
        {
            //Arrange
            var Operation = new Division();

            //Act
            var result = Operation.Caculate(155, 5);

            //Assert
            Assert.That(result, Is.EqualTo(31));
        }

        [Test]
        public void DivisionByZero_ThrowsException()
        {
            //Arrange
            var Operation = new Division();

            //Act
            var ex = Assert.Throws<DivideByZeroException>(() => { Operation.Caculate(522, 0); });

            //Assert
            StringAssert.Contains("Erreur", ex.Message.ToString());
        }
    }
}
