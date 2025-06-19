using System.Reflection;
using tax_demo.Components.Abstractions;
using tax_demo.Components.Interfaces;

namespace tax_demo.Components.Models
{
    // Class object for our tax data container
    public class TaxBreakdown : AbstractTaxBreakdown, ITaxBreakdown
    {
        // Constant class props for calculations
        public const int Months = 12;
        public const int ATierTaxUpperBound = 5000;
        public const double ATierTaxRate = .20;
        public const int BTierTaxUpperBound = 20000;
        public const double BTierTaxRate = .40;

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
            CalculateNetSalary(grossAnnualSalary);

            GrossAnnualSalary = grossAnnualSalary;
            GrossMonthlySalary = grossAnnualSalary/Months;
            NetMonthlySalary = NetAnnualSalary/Months;
            MonthlyTaxPaid = AnnualTaxPaid/Months;
        }

        public override void CalculateNetSalary(double grossAnnualSalary)
        {
            // Method to calculate net annual salary and total annual taxes
            if(grossAnnualSalary > ATierTaxUpperBound && grossAnnualSalary <= BTierTaxUpperBound)
            {
                double taxableAmountBTier = grossAnnualSalary - ATierTaxUpperBound;
                double bTierTaxes = taxableAmountBTier * ATierTaxRate;

                NetAnnualSalary = GrossAnnualSalary - AnnualTaxPaid;
                AnnualTaxPaid = bTierTaxes;
            }
            else if (grossAnnualSalary > BTierTaxUpperBound)
            {
                double taxableAmountBTier = grossAnnualSalary - ATierTaxUpperBound;
                double taxableAmountCTier = grossAnnualSalary - BTierTaxUpperBound;

                double bTierTaxes = taxableAmountBTier * ATierTaxRate;
                double cTierTaxes = taxableAmountCTier * BTierTaxRate;

                NetAnnualSalary = GrossAnnualSalary - AnnualTaxPaid;
                AnnualTaxPaid = bTierTaxes + cTierTaxes;
            }
        }
    }
}
