using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TaxDemo.Tests.TestSetups;


namespace TaxDemo.Tests
{
    [TestFixture]
    public class ChromeCalculatorTests : TestWebDriverBase
    {
        // Chrome selenium tests for app calculator page
        protected ChromeDriver CalculatorDriver => Driver;

        [Test]
        public void CheckPageTitle()
        {
            CalculatorDriver.Navigate().GoToUrl(CalculatorURL);
            var title = CalculatorDriver.FindElement(By.TagName("h1"));
            string titleText = title.Text;
            Assert.That("Tax Calculator Input" == titleText);
        }

        [Test]
        public void CheckSalaryFieldExists()
        {
            CalculatorDriver.Navigate().GoToUrl(CalculatorURL);
            var salaryField = CalculatorDriver.FindElement(By.Id("salary-value"));
            Assert.That(salaryField != null);
        }

        [Test]
        public void CheckCalculationButtonExists()
        {
            CalculatorDriver.Navigate().GoToUrl(CalculatorURL);
            var calculationButton = CalculatorDriver.FindElement(By.Id("calculate-button"));
            var buttonText = calculationButton.Text;
            Assert.That("Calculate" == buttonText);
        }
    }
}
