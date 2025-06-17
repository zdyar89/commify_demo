using tax_demo.Components.Abstractions;
using tax_demo.Components.Interfaces;

namespace tax_demo.Components.Models
{
    public class TaxBreakdown : AbstractTaxBreakdown, ITaxBreakdown
    {
        public const int Months = 12;
        public const int ATierTaxUpperBound = 5000;
        public const double ATierTaxRate = .20;
        public const int BTierTaxUpperBound = 20000;
        public const double BTierTaxRate = .40;

        public double GrossAnnualSalary { get; set; }
        public double GrossMonthlySalary { get; set; }
        public double NetAnnualSalary { get; set; }
        public double NetMonthlySalary { get; set; }
        public double AnnualTaxPaid { get; set; }
        public double MonthlyTaxPaid { get; set; }
        public TaxBreakdown(double grossAnnualSalary, double netAnnualSalary, double annualTaxPaid)
        {
            // Constructor for TaxBreakdown objects
            CalculateNetSalary(grossAnnualSalary);

            GrossAnnualSalary = grossAnnualSalary;
            GrossMonthlySalary = grossAnnualSalary/Months;
            NetAnnualSalary = netAnnualSalary;
            NetMonthlySalary = netAnnualSalary/Months;
            AnnualTaxPaid = annualTaxPaid;
            MonthlyTaxPaid = annualTaxPaid/Months;
        }

        public override void CalculateNetSalary(double grossAnnualSalary)
        {
            // Method to calculate salary after taxes
            if(grossAnnualSalary > ATierTaxUpperBound && grossAnnualSalary <= BTierTaxUpperBound)
            {
                double taxableAmountBTier = grossAnnualSalary - ATierTaxUpperBound;
                double bTierTaxes = taxableAmountBTier * ATierTaxRate;

                AnnualTaxPaid = bTierTaxes;
                NetAnnualSalary = GrossAnnualSalary - AnnualTaxPaid;
            }
            else if (grossAnnualSalary > BTierTaxUpperBound)
            {
                double taxableAmountBTier = grossAnnualSalary - ATierTaxUpperBound;
                double taxableAmountCTier = grossAnnualSalary - BTierTaxUpperBound;

                double bTierTaxes = taxableAmountBTier * ATierTaxRate;
                double cTierTaxes = taxableAmountCTier * BTierTaxRate;

                AnnualTaxPaid = bTierTaxes + cTierTaxes;
                NetAnnualSalary = GrossAnnualSalary - AnnualTaxPaid;
            }
        }
    }
}
