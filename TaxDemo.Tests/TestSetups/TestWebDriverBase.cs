using OpenQA.Selenium.Chrome;


namespace TaxDemo.Tests.TestSetups
{
    [TestFixture]
    public class TestWebDriverBase
    {
        // Base setup class for WebDriver tests

        protected ChromeDriver driverCalculatorPage;
        protected ChromeDriver driverResultPage;

        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            driverCalculatorPage = new ChromeDriver(chromeOptions);
            driverCalculatorPage
                .Navigate()
                .GoToUrl("https://localhost:44345/calculator");

            driverResultPage = new ChromeDriver(chromeOptions);
            driverResultPage
                .Navigate()
                .GoToUrl("https://localhost:44345/result");
        }

        [TearDown]
        public void Teardown()
        {
            driverCalculatorPage.Quit();
            driverCalculatorPage.Dispose();

            driverResultPage.Quit();
            driverResultPage.Dispose();
        }
    }
}
