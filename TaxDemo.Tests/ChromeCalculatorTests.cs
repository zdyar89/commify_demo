using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace TaxDemo.Tests
{
    [TestFixture]
    public class ChromeCalculatorTests
    {   
        // Chrome selenium tests for app calculator page
        private ChromeDriver driver;

        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl("https://localhost:44345/calculator");
        }

        [Test]
        public void CheckPageTitle()
        {
            var title = driver.FindElement(By.TagName("h1"));
            string titleText = title.Text;
            Assert.That("Tax Calculator Input" == titleText);
        }

        [Test]
        public void CheckSalaryFieldExists()
        {
            var salaryField = driver.FindElement(By.Id("salary-value"));
            Assert.That(salaryField != null);
        }

        [Test]
        public void CheckCalculationButtonExists()
        {
            var calculationButton = driver.FindElement(By.TagName("button"));
            Assert.That(calculationButton != null);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
