using OpenQA.Selenium;
using TaxDemo.Tests.TestSetups;


namespace TaxDemo.Tests
{
    [TestFixture]
    public class ChromeCalculatorTests : TestWebDriverBase
    {
        // Chrome selenium tests for app calculator page

        [Test]
        public void CheckPageTitle()
        {
            var title = driverCalculatorPage.FindElement(By.TagName("h1"));
            string titleText = title.Text;
            Assert.That("Tax Calculator Input" == titleText);
        }

        [Test]
        public void CheckSalaryFieldExists()
        {
            var salaryField = driverCalculatorPage.FindElement(By.Id("salary-value"));
            Assert.That(salaryField != null);
        }

        [Test]
        public void CheckCalculationButtonExists()
        {
            var calculationButton = driverCalculatorPage.FindElement(By.TagName("button"));
            Assert.That(calculationButton != null);
        }
    }
}
