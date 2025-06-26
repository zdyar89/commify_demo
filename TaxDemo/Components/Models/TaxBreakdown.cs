using TaxDemo.Components.Interfaces;


namespace TaxDemo.Components.Models
{
    // Class object for our tax data container
    public class TaxBreakdown : ITaxForm
    {
        // Class props

        private readonly ILogger _logger;
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

            try
            {
                GrossMonthlySalary = GrossAnnualSalary / TaxConstants.Months;

                if(GrossAnnualSalary <= TaxConstants.ATierTaxUpperBound)
                {
                    NetAnnualSalary = GrossAnnualSalary;
                    NetMonthlySalary = NetAnnualSalary / TaxConstants.Months;
                }
                else if (GrossAnnualSalary > TaxConstants.ATierTaxUpperBound && GrossAnnualSalary <= TaxConstants.BTierTaxUpperBound)
                {
                    double taxableAmountBTier = GrossAnnualSalary - TaxConstants.ATierTaxUpperBound;
                    double bTierTaxes = taxableAmountBTier * TaxConstants.ATierTaxRate;

                    AnnualTaxPaid = bTierTaxes;
                    MonthlyTaxPaid = AnnualTaxPaid / TaxConstants.Months;

                    NetAnnualSalary = GrossAnnualSalary - AnnualTaxPaid;
                    NetMonthlySalary = NetAnnualSalary / TaxConstants.Months;
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
            catch(Exception e)
            {
                _logger.LogError($"An error has occurred for CalculateTaxItemization(): {e}");
            }
        }
    }
}
