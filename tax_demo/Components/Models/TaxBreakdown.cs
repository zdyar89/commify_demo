using tax_demo.Components.Interfaces;

namespace tax_demo.Components.Models
{
    // Class object for our tax data container
    public class TaxBreakdown : ITaxForm
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
        }

        public void CalculateTaxItemization()
        {
            // Method to calculate net annual salary and total annual taxes

            GrossMonthlySalary = GrossAnnualSalary / TaxConstants.Months;

            if (GrossAnnualSalary > TaxConstants.ATierTaxUpperBound && GrossAnnualSalary <= TaxConstants.BTierTaxUpperBound)
            {
                double taxableAmountBTier = GrossAnnualSalary - TaxConstants.ATierTaxUpperBound;
                double bTierTaxes = taxableAmountBTier * TaxConstants.ATierTaxRate;

                AnnualTaxPaid = bTierTaxes;
                NetAnnualSalary = GrossAnnualSalary - AnnualTaxPaid;
            }
            else if (GrossAnnualSalary > TaxConstants.BTierTaxUpperBound)
            {
                double taxableAmountBTier = TaxConstants.BTierTaxUpperBound - TaxConstants.ATierTaxUpperBound;
                double taxableAmountCTier = GrossAnnualSalary - TaxConstants.BTierTaxUpperBound;

                double bTierTaxes = taxableAmountBTier * TaxConstants.ATierTaxRate;
                double cTierTaxes = taxableAmountCTier * TaxConstants.BTierTaxRate;

                AnnualTaxPaid = bTierTaxes + cTierTaxes;
                MonthlyTaxPaid = AnnualTaxPaid / TaxConstants.Months;

                NetAnnualSalary = GrossAnnualSalary - AnnualTaxPaid;
                NetMonthlySalary = NetAnnualSalary / TaxConstants.Months;
            }
        }
    }
}
