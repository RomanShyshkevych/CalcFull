using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcFull;

namespace TestApiCalc
{
    [TestClass]
    public class TestWinForm
    {
        [DataTestMethod]
        [DataRow(15, 15, '+', 30)]
        [DataRow(189, 89, '-', 100)]
        [DataRow(16, 8, '*', 128)]
        [DataRow(256, 16, '/', 16)]
        public void TestCalcAPI(int a, int b, char op, int exp)
        {
            Form1 form = new Form1();
            int res = form.Calc(a, b, op);
            Assert.AreEqual(exp, res);
        }
    }
}
