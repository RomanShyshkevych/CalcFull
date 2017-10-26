using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.Finders;

namespace Test1
{
    [TestClass]
    public class TestCalcFull
    {
        public static Application application;
        public static Window window;

        [ClassInitialize]
        public static void ClassSetUp(TestContext e)
        {
            application = Application.Launch(@"D:\COURSE\calculators\CalcFull\CalcFull\bin\Debug\CalcFull.exe");
            window = application.GetWindows()[0];
        }
        [ClassCleanup]
        public static void ClassCleanUp()
        {
            application.Kill();
        }
        [TestInitialize]
        public void SetUp()
        {
            window.Get<TextBox>(SearchCriteria.ByAutomationId("txtResult")).SetValue("");
        }
        [DataTestMethod]
        [DataRow("btn_zero", true)]
        [DataRow("btn_one", true)]
        [DataRow("btn_two", true)]
        [DataRow("btn_three", true)]
        [DataRow("btn_four", true)]
        [DataRow("btn_five", true)]
        [DataRow("btn_six", true)]
        [DataRow("btn_seven", true)]
        [DataRow("btn_eight", true)]
        [DataRow("btn_nine", true)]
        [DataRow("btn_plus", true)]
        [DataRow("btn_minus", true)]
        [DataRow("btn_multiply", true)]
        [DataRow("btn_divide", true)]
        [DataRow("btn_equal", true)]
        public void Test_CalcFull_ExistElem(string a, bool exp)
        {
            bool res = window.Get<Button>(SearchCriteria.ByAutomationId(a)).Enabled;
            Assert.AreEqual(exp, res);
        }
        [DataTestMethod]
        [DataRow("btn_zero", "0")]
        [DataRow("btn_one", "1")]
        [DataRow("btn_two", "2")]
        [DataRow("btn_three", "3")]
        [DataRow("btn_four", "4")]
        [DataRow("btn_five", "5")]
        [DataRow("btn_six", "6")]
        [DataRow("btn_seven", "7")]
        [DataRow("btn_eight", "8")]
        [DataRow("btn_nine", "9")]
        public void Test_CalcFull_SimpleCheck(string a, string exp)
        {
            window.Get<Button>(SearchCriteria.ByAutomationId(a)).Click();
            string res = window.Get<TextBox>(SearchCriteria.ByAutomationId("txtResult")).Text;
            Assert.AreEqual(exp, res);
        }
        [DataTestMethod]
        [DataRow("btn_one", "btn_two", "btn_three", "btn_four", "1234")]
        [DataRow("btn_five", "btn_six", "btn_seven", "btn_eight", "5678")]
        public void Test_CalcFull_ComplexCheck(string a, string a1, string a2, string a3, string exp)
        {
            window.Get<Button>(SearchCriteria.ByAutomationId(a)).Click();
            window.Get<Button>(SearchCriteria.ByAutomationId(a1)).Click();
            window.Get<Button>(SearchCriteria.ByAutomationId(a2)).Click();
            window.Get<Button>(SearchCriteria.ByAutomationId(a3)).Click();
            string res = window.Get<TextBox>(SearchCriteria.ByAutomationId("txtResult")).Text;
            Assert.AreEqual(exp, res);
        }
        [DataTestMethod]
        [DataRow("btn_one", "btn_seven", "btn_plus", "8")]
        [DataRow("btn_four", "btn_three", "btn_minus", "1")]
        [DataRow("btn_five", "btn_six", "btn_multiply", "30")]
        [DataRow("btn_eight", "btn_two", "btn_divide", "4")]
        public void CalcFull_RealJob(string a, string b, string op, string exp)
        {
            window.Get<Button>(SearchCriteria.ByAutomationId(a)).Click();
            window.Get<Button>(SearchCriteria.ByAutomationId(op)).Click();
            window.Get<Button>(SearchCriteria.ByAutomationId(b)).Click();
            window.Get<Button>(SearchCriteria.ByAutomationId("btn_equal")).Click();
            string res = window.Get<TextBox>(SearchCriteria.ByAutomationId("txtResult")).Text;
            Assert.AreEqual(exp, res);
        }
    }
}
