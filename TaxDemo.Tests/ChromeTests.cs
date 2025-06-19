using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxDemo.Tests
{
    [TestFixture]
    public class ChromeTests
    {
        private ChromeDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:32783/calculator");
        }
        [Test]
        public void CheckPageTitle()
        {
            var title = driver.FindElement(By.TagName("h1")).ToString();
            Console.WriteLine(title);
            Assert.That("Tax Calculator Input" == title);
        }

        [Test]
        public void CheckSalaryFieldExists()
        {
            var salaryField = driver.FindElement(By.Id(""));
            Assert.That(salaryField != null);
        }
        [Test]
        public void CheckCalculationButtonExists()
        {
            var calculationButton = driver.FindElement(By.Id(""));
            Assert.That(calculationButton != null);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }


    }
}
