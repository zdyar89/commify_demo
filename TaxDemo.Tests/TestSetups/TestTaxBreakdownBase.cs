using Microsoft.Extensions.Logging;
using TaxDemo.Components.Models;


namespace TaxDemo.Tests.TestSetups
{
    [SetUpFixture]
    public class TestTaxFormBase
    {
        // Base setup class for TaxForm tests

        protected ILogger _logger;

        protected double TestGrossAnnualSalaryATier = TaxConstants.ATierTaxUpperBound;
        protected double TestGrossAnnualSalaryBTier = TaxConstants.BTierTaxUpperBound;

        public TaxBreakdown Breakdown;

        [OneTimeSetUp]
        public void Setup()
        {
            _logger = new LoggerFactory().CreateLogger("Test");

            Breakdown = new TaxBreakdown(0);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
        
        }
    }
}
