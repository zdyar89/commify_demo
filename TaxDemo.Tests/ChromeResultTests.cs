using OpenQA.Selenium;
using TaxDemo.Tests.TestSetups;


namespace TaxDemo.Tests
{
    [TestFixture]
    public class ChromeResultTests : TestWebDriverBase
    {
        // Chrome selenium tests for app result page

        [Test]
        public void CheckPageTitle()
        {
            var title = driverResultPage.FindElement(By.TagName("h1"));
            string titleText = title.Text;
            Console.WriteLine(titleText);
            Assert.That("Tax Calculator Result" == titleText);
        }

        [Test]
        public void CheckSalaryFieldExists()
        {
            var salaryField = driverResultPage.FindElement(By.Id("salary-value"));
            Assert.That(salaryField != null);
        }

        [Test]
        public void CheckRecalculationButtonExists()
        {
            var calculationButton = driverResultPage.FindElement(By.TagName("button"));
            Assert.That(calculationButton != null);
        }

        [Test]
        public void CheckTaxBreakdownTableExists()
        {
            var salaryField = driverResultPage.FindElement(By.ClassName("quickgrid"));
            Assert.That(salaryField != null);
        }
    }
}
