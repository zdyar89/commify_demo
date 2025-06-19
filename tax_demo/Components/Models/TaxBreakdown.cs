using System.Reflection;
using tax_demo.Components.Abstractions;
using tax_demo.Components.Interfaces;

namespace tax_demo.Components.Models
{
    // Class object for our tax data container
    public class TaxBreakdown : AbstractTaxBreakdown, ITaxBreakdown
    {
        // Class props
        public double GrossAnnualSalary { get; set; }
        public double GrossMonthlySalary { get; set; }
        public double NetAnnualSalary { get; set; }
        public double NetMonthlySalary { get; set; }
        public double AnnualTaxPaid { get; set; }
        public double MonthlyTaxPaid { get; set; }

        public TaxBreakdown(double grossAnnualSalary)
        {
            // Constructor for TaxBreakdown objects
            GrossAnnualSalary = grossAnnualSalary;
            CalculateNetSalary(this.GrossAnnualSalary);

            GrossMonthlySalary = grossAnnualSalary/TaxConstants.Months;
            NetMonthlySalary = NetAnnualSalary/TaxConstants.Months;
            MonthlyTaxPaid = AnnualTaxPaid/TaxConstants.Months;
        }

        public override void CalculateNetSalary(double grossAnnualSalary)
        {
            // Method to calculate net annual salary and total annual taxes
            if(grossAnnualSalary > TaxConstants.ATierTaxUpperBound && grossAnnualSalary <= TaxConstants.BTierTaxUpperBound)
            {
                double taxableAmountBTier = grossAnnualSalary - TaxConstants.ATierTaxUpperBound;
                double bTierTaxes = taxableAmountBTier * TaxConstants.ATierTaxRate;

                AnnualTaxPaid = bTierTaxes;
                NetAnnualSalary = grossAnnualSalary - AnnualTaxPaid;
            }
            else if (grossAnnualSalary > TaxConstants.BTierTaxUpperBound)
            {
                double taxableAmountBTier = grossAnnualSalary - TaxConstants.ATierTaxUpperBound;
                double taxableAmountCTier = grossAnnualSalary - TaxConstants.BTierTaxUpperBound;

                double bTierTaxes = taxableAmountBTier * TaxConstants.ATierTaxRate;
                double cTierTaxes = taxableAmountCTier * TaxConstants.BTierTaxRate;

                AnnualTaxPaid = bTierTaxes + cTierTaxes;
                NetAnnualSalary = grossAnnualSalary - AnnualTaxPaid;
                Console.WriteLine("test");
            }
        }
    }
}
