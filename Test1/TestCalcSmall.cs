using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.Finders;

namespace TestCalc
{
    [TestClass]
    public class TestCalcSmall
    {
        [DataTestMethod]
        [DataRow("11", "7", "+", "18")]
        [DataRow("14", "3", "-", "11")]
        [DataRow("15", "6", "*", "90")]
        [DataRow("80", "20", "/", "4")]
        public void CalcSmall_Txt(string a, string b, string op, string exp)
        {
            Application application = Application.Launch(@"D:\COURSE\calculators\CalcWinForm\CalcWinForm\bin\Debug\CalcWinForm.exe");
            Window window = application.GetWindows()[0];
            window.Get<TextBox>(SearchCriteria.ByAutomationId("text_a")).SetValue(a);
            window.Get<TextBox>(SearchCriteria.ByAutomationId("text_b")).SetValue(b);
            window.Get<TextBox>(SearchCriteria.ByAutomationId("text_op")).SetValue(op);
            window.Get<Button>(SearchCriteria.ByAutomationId("btn_res")).Click();
            string res = window.Get<TextBox>(SearchCriteria.ByAutomationId("text_res")).Text;
            Assert.AreEqual(exp, res);
            application.Kill();
        }
    }
}
