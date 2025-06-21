using tax_demo.Components.Models;
using tax_demo.Components.Interfaces;


namespace TaxDemo.Tests.TestSetups
{
    [TestFixture(typeof(TaxBreakdown))]
    public class TestTaxFormBase<ITaxForm>
    {
        // Base setup class for TaxForm tests

        public double testGrossAnnualSalaryATier = 5000;
        protected double testGrossAnnualSalaryBTier = 20000;
        protected double testGrossAnnualSalaryCTier = 40000;

        protected TaxBreakdown taxBreakdown = new TaxBreakdown(0);

        [SetUp]
        public void Setup()
        {
            
        }
    }
}
