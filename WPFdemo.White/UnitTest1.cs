using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using System.Diagnostics;

namespace WPFdemo.White
{
    [TestClass]

    public class UnitTest1
    {
        
        public Application app;
        [TestMethod]
        public void InvokeApplication()
        {
            //Launching the application
            string apppath = @"C:\Windows\system32\Calc.exe";
            var prc = new ProcessStartInfo(apppath);
            app = Application.Launch(prc);

            //Getting the window object 
            Window WndCalc = (Window)app.GetWindow("Calculator");

            //Getting the controls
            //By Automation id
            Button btnFour = WndCalc.Get<Button>(SearchCriteria.ByAutomationId("134"));
            //By Text
            Button btnFive = WndCalc.Get<Button>(SearchCriteria.ByText("5"));
            Button btnMultiply = WndCalc.Get<Button>(SearchCriteria.ByAutomationId("92"));
            //By automation id and index
            Button btnEquals = WndCalc.Get<Button>(SearchCriteria.ByAutomationId("121").AndIndex(0));

            //Performing calculation
            btnFour.Click();
            btnMultiply.Click();
            btnFive.Click();
            btnEquals.Click();
            Label txtResult = WndCalc.Get<Label>(SearchCriteria.ByAutomationId("158"));
            //Assert will check if the expected equals Actual
            Assert.AreEqual("20", txtResult.Name);


           
        }
    }
}

