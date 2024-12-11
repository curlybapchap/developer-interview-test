namespace Smartwyre.DeveloperTest.Types;

public class FixedCashAmount : IIncentiveType
{
    public void CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request)
    {
        if (rebate == null)
        {
            //success = false;
        }
        else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount))
        {
            //success = false;
        }
        else if (rebate.Amount == 0)
        {
            //success = false;
        }
        else
        {
            rebateAmount = rebate.Amount;
            success = true;
        }
    }

    public bool success { get; set; } = false;
    public decimal rebateAmount { get; set; } = 0.0m;
}
