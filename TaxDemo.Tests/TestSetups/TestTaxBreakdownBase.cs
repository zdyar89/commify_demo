using TaxDemo.Components.Models;


namespace TaxDemo.Tests.TestSetups
{
    [TestFixture(typeof(TaxBreakdown))]
    public class TestTaxFormBase<ITaxForm>
    {
        // Base setup class for TaxForm tests

        protected double testGrossAnnualSalaryATier = TaxConstants.ATierTaxUpperBound;
        protected double testGrossAnnualSalaryBTier = TaxConstants.BTierTaxUpperBound;

        protected TaxBreakdown taxBreakdown = new TaxBreakdown(0);

        [SetUp]
        public void Setup()
        {
            
        }
    }
}
