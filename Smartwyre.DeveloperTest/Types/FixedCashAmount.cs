namespace Smartwyre.DeveloperTest.Types;

public class FixedCashAmount : IRebateCalculator
{
    public CalculateRebateResult CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request)
    {
        CalculateRebateResult rebateResult = new CalculateRebateResult() { Success = false, RebateAmount = 0 };
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
        return rebateResult;
    }
}