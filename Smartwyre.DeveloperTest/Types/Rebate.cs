namespace Smartwyre.DeveloperTest.Types;

public class Rebate
{
    public string Identifier { get; set; }
    public IncentiveType Incentive { get; set; }
    public decimal Amount { get; set; }
    public decimal Percentage { get; set; }

    public IRebateCalculator RebateCalculator
    {
        get
        {
            IRebateCalculator rebateCalculator;
            switch (this.Incentive)
            {
                case IncentiveType.FixedCashAmount:
                    rebateCalculator = new FixedCashAmount();
                    break;
                case IncentiveType.FixedRateRebate:
                    rebateCalculator = new FixedRateRebate();
                    break;
                case IncentiveType.AmountPerUom:
                    rebateCalculator = new AmountPerUom();
                    break;
                default:
                    rebateCalculator = new FixedCashAmount();
                    break;
            }
            return rebateCalculator;
        }
    }
}
