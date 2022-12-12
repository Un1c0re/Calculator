using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void CalcIsStarted()
        {
            var calc = new Calc();
        }

        [TestMethod]
        public void Calc_ShouldShowZeroWhenStarted()
        {
            var calc = new Calc();
            Assert.AreEqual(calc.Display, 0);
        }

        [TestMethod]
        public void Calc_ShouldShowDigitWhenEnterDigit()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Three);

            Assert.AreEqual(calc.Display, 3);
        }

        [TestMethod]
        public void Calc_ShouldShowNumberWhenEnterNumber()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Three);

            Assert.AreEqual(calc.Display, 33);
        }

        [TestMethod]
        public void Calc_Sum2Numbers()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Plus);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Equal);

            Assert.AreEqual(calc.Display, 36);
        }

        [TestMethod]
        public void Calc_ShouldSumNTimes()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Plus);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Plus);

            Assert.AreEqual(calc.Display, 36);

            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Equal);

            Assert.AreEqual(calc.Display, 39);
        }

        [TestMethod]
        public void Calc_DoubleEqual()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Plus);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Equal);
            calc.InputCommand.Execute(MathOperations.Equal);

            Assert.AreEqual(calc.Display, 39);
        }

        [TestMethod]
        public void Calc_ShouldRepeatOperation()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Plus);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Equal);

            calc.InputCommand.Execute(MathOperations.Seven);
            calc.InputCommand.Execute(MathOperations.Plus);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Equal);

            Assert.AreEqual(calc.Display, 10);
        }

        [TestMethod]
        public void Calc_SubstractWithoutOperator2()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.Plus);
            calc.InputCommand.Execute(MathOperations.Equal);

            Assert.AreEqual(calc.Display, 4);
        }

        [TestMethod]
        public void Calc_MemoryPlus()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemoryPlus);
            calc.InputCommand.Execute(MathOperations.Five);
            calc.InputCommand.Execute(MathOperations.MemoryRead);

            Assert.AreEqual(calc.Display, 2);
        }

        [TestMethod]
        public void Calc_MemoryMinus()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemoryPlus);
            calc.InputCommand.Execute(MathOperations.One);
            calc.InputCommand.Execute(MathOperations.MemoryMinus);
            calc.InputCommand.Execute(MathOperations.MemoryRead);

            Assert.AreEqual(calc.Display, 1);
        }

        [TestMethod]
        public void Calc_MemorySet()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.Five);
            calc.InputCommand.Execute(MathOperations.MemoryRead);

            Assert.AreEqual(calc.Display, 2);
        }

        [TestMethod]
        public void Calc_MemoryClear()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.Six);
            calc.InputCommand.Execute(MathOperations.Seven);
            calc.InputCommand.Execute(MathOperations.MemoryClear);
            calc.InputCommand.Execute(MathOperations.MemoryRead);

            Assert.AreEqual(calc.Display, 0);
        }

        [TestMethod]
        public void Calc_NewNumberAfterEqual()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.One);
            calc.InputCommand.Execute(MathOperations.Equal);
            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.Equal);

            Assert.AreEqual(calc.Display, 2);
        }

        [TestMethod]
        public void Calc_HistoryIsWork()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Equal);
            calc.InputCommand.Execute(MathOperations.Seven);
            calc.InputCommand.Execute(MathOperations.Equal);
            calc.InputCommand.Execute(MathOperations.Equal);
            calc.ListItemReadCommand.Execute(calc.HistoryList[0]);

            Assert.AreEqual(calc.Display, 7);
            Assert.AreEqual(calc.HistoryList.Count, 3);
            Assert.AreEqual(calc.HistoryList[0].Value, 7);
            Assert.AreEqual(calc.HistoryList[1].Value, 7);
            Assert.AreEqual(calc.HistoryList[2].Value, 3);
        }

        [TestMethod]
        public void Calc_MemoryAddToList()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            Assert.AreEqual(calc.MemoryList[0].Value, 2);
        }

        [TestMethod]
        public void Calc_ClearMemory()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.MemoryClear);
            Assert.AreEqual(calc.MemoryList.Count, 0);
        }

        [TestMethod]
        public void Calc_OperationPlusInMemory()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.MemoryPlus);
            Assert.AreEqual(calc.MemoryList[0].Value, 5);
        }

        [TestMethod]
        public void Calc_operationMinusInMemory()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.MemoryMinus);
            Assert.AreEqual(calc.MemoryList[0].Value, -1);
        }

        [TestMethod]
        public void Calc_MemoryPlusButton()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.Seven);
            calc.MemoryPlusCommand.Execute(calc.MemoryList[0]);
            Assert.AreEqual(calc.MemoryList[0].Value, 9);
        }

        [TestMethod]
        public void Calc_MemoryMinusButton()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Seven);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.Two);
            calc.MemoryMinusCommand.Execute(calc.MemoryList[0]);
            Assert.AreEqual(calc.MemoryList[0].Value, 5);
        }

        [TestMethod]
        public void Calc_Operand2EnterAfterOperand1IsZero()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Seven);
            calc.InputCommand.Execute(MathOperations.Plus);
            calc.InputCommand.Execute(MathOperations.Zero);
            calc.InputCommand.Execute(MathOperations.Five);
            calc.InputCommand.Execute(MathOperations.Equal);

            Assert.AreEqual(calc.Display, 12);
        }
    }
}