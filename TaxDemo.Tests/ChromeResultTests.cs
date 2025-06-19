using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace TaxDemo.Tests
{
    public class ChromeResultTests
    {
        // Chrome selenium tests for app result page
        private ChromeDriver driver;

        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl("https://localhost:44345/result");
        }

        [Test]
        public void CheckPageTitle()
        {
            var title = driver.FindElement(By.TagName("h1"));
            string titleText = title.Text;
            Assert.That("Tax Calculator Result" == titleText);
        }

        [Test]
        public void CheckSalaryFieldExists()
        {
            var salaryField = driver.FindElement(By.Id("salary-value"));
            Assert.That(salaryField != null);
        }

        [Test]
        public void CheckRecalculationButtonExists()
        {
            var calculationButton = driver.FindElement(By.TagName("button"));
            Assert.That(calculationButton != null);
        }

        [Test]
        public void CheckTaxBreakdownTableExists()
        {
            var salaryField = driver.FindElement(By.ClassName("quickgrid"));
            Assert.That(salaryField != null);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
