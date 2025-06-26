using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TaxDemo.Tests.TestSetups;


namespace TaxDemo.Tests
{
    [TestFixture]
    public class ChromeResultTests : TestWebDriverBase
    {
        // Chrome selenium tests for app result page
        protected ChromeDriver ResultDriver => Driver;

        [Test]
        public void CheckPageTitle()
        {
            ResultDriver.Navigate().GoToUrl(ResultURL);
            var title = ResultDriver.FindElement(By.TagName("h1"));
            string titleText = title.Text;
            Assert.That("Tax Calculator Result" == titleText);
        }

        [Test]
        public void CheckSalaryFieldExists()
        {
            ResultDriver.Navigate().GoToUrl(ResultURL);
            var salaryField = ResultDriver.FindElement(By.Id("salary-value"));
            Assert.That(salaryField != null);
        }

        [Test]
        public void CheckRecalculationButtonExists()
        {
            ResultDriver.Navigate().GoToUrl(ResultURL);
            var recalculationButton = ResultDriver.FindElement(By.Id("recalculate-button"));
            var buttonText = recalculationButton.Text;
            Assert.That("Recalculate" == buttonText);
        }

        [Test]
        public void CheckTaxBreakdownTableExists()
        {
            ResultDriver.Navigate().GoToUrl(ResultURL);
            var salaryField = ResultDriver.FindElement(By.TagName("table"));
            Assert.That(salaryField != null);
        }
    }
}
