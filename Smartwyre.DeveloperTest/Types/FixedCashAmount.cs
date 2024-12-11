namespace Smartwyre.DeveloperTest.Types;

public class FixedCashAmount : IIncentiveType
{
    public void CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request)
    {
        if (rebate == null)
        {
            rebateResult.Success = false;
        }
        else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount))
        {
            rebateResult.Success = false;
        }
        else if (rebate.Amount == 0)
        {
            rebateResult.Success = false;
        }
        else
        {
            rebateResult.RebateAmount = rebate.Amount;
            rebateResult.Success = true;
        }
    }

    public CalculateRebateResult rebateResult { get; set; } = new CalculateRebateResult() { Success = false, RebateAmount = 0 };
}