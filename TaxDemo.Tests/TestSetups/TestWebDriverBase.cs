using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;


namespace TaxDemo.Tests.TestSetups
{
    [SetUpFixture]
    public class TestWebDriverBase
    {
        // Base setup class for WebDriver tests

        protected ILogger _logger;

        protected static ChromeDriver Driver;

        protected string TestEmail = "testUser01@testprovider01.com";
        protected string TestPassword = "<PlaceHolder>";
        protected string RegistrationURL = "https://localhost:44345/Account/Register";
        protected string LoginURL = "https://localhost:44345/Account/Login";
        protected string CalculatorURL = "https://localhost:44345/calculator";
        protected string ResultURL = "https://localhost:44345/result";
        protected string DeleteTestUserFile = "DeleteTestUserAccount.sql";

        private const string TestConnectionString = "Server=localhost,1433;Database=IdentityContext;User ID=sa;Password=<PlaceHolder>;Persist Security Info=False;TrustServerCertificate=true;";

        [OneTimeSetUp]
        public void Setup()
        {
            _logger = new LoggerFactory().CreateLogger("Test");

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--start-maximized");
            Driver = new ChromeDriver(chromeOptions);

            try
            {
                RegisterTestUser(Driver, RegistrationURL, TestEmail, TestPassword, _logger);
                LoginTestUser(Driver, LoginURL, TestEmail, TestPassword, _logger);
            }
            catch (Exception e)
            {
                _logger.LogError($"An exception occurred during a ChromeDriver object operation: {e}");
            }
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            Driver.Quit();
            Driver.Dispose();

            DeleteTestUserAccount(DeleteTestUserFile,TestConnectionString, TestEmail, _logger);
        }
        public static void RegisterTestUser(ChromeDriver driver, string registrationURL, string email, string password, ILogger logger)
        {
            // Static method to register test user

            try
            {
                driver.Navigate().GoToUrl(registrationURL);
                driver.FindElement(By.Name("Input.Email")).SendKeys(email);
                driver.FindElement(By.Name("Input.Password")).SendKeys(password);
                driver.FindElement(By.Name("Input.ConfirmPassword")).SendKeys(password);
                driver.FindElement(By.TagName("button")).Click();

                Thread.Sleep(5000);
                driver.FindElement(By.Id("confirmationLink")).Click();
            }
            catch (Exception e)
            {
                logger.LogError($"An exception occurred during the ChromeDriver site registration operation: {e}");
            }
        }
        public static void LoginTestUser(ChromeDriver driver, string loginURL, string email, string password, ILogger logger)
        {
            // Static method to login test user

            try
            {
                driver.Navigate().GoToUrl(loginURL);
                driver.FindElement(By.Name("Input.Email")).SendKeys(email);
                driver.FindElement(By.Name("Input.Password")).SendKeys(password);
                driver.FindElement(By.TagName("button")).Click();
            }
            catch (Exception e)
            {
                logger.LogError($"An exception occurred during the ChromeDriver login operation: {e}");
            }
        }
        public static void DeleteTestUserAccount(string scriptFileName, string connectionString, string email, ILogger logger)
        {
            // Static method to delete test user from db

            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = $"TaxDemo.Tests.TestSetups.{scriptFileName}";

                using var stream = assembly.GetManifestResourceStream(resourceName);
                using var reader = new StreamReader(stream);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string script = reader.ReadToEnd();
                    SqlCommand command = new SqlCommand(script, conn);
                    command.Parameters.AddWithValue("@UserParam", email);
                    command.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (SqlException e)
            {
                logger.LogError($"An exception occurred during the test user deletion operation: {e}");
            }
        }
    }
}
