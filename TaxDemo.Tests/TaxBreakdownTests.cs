using TaxDemo.Tests.TestSetups;
using NUnit.Framework.Internal;


namespace TaxDemo.Tests
{
    [TestFixture]
    public class TaxBreakdownTests : TestTaxFormBase
    {   
        // TaxBreakdown data object tests
        
        [Test]
        public void CalculateATierTax()
        {
            Breakdown.GrossAnnualSalary = TestGrossAnnualSalaryATier;
            Breakdown.CalculateTaxItemization();
            Assert.That(Breakdown.AnnualTaxPaid == 0);
            Assert.That(Breakdown.MonthlyTaxPaid == 0);
            Assert.That(Breakdown.NetAnnualSalary == Breakdown.GrossAnnualSalary);
            Assert.That(Breakdown.NetMonthlySalary == Breakdown.GrossMonthlySalary);
        }

        [Test]
        public void CalculateBTierTax()
        {
            Breakdown.GrossAnnualSalary = TestGrossAnnualSalaryBTier;
            Breakdown.CalculateTaxItemization();
            Assert.That(Breakdown.AnnualTaxPaid > 0);
            Assert.That(Breakdown.MonthlyTaxPaid > 0);
            Assert.That(Breakdown.NetAnnualSalary != Breakdown.GrossAnnualSalary);
            Assert.That(Breakdown.NetMonthlySalary != Breakdown.GrossMonthlySalary);
        }
    }
}
