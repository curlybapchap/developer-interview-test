namespace Smartwyre.DeveloperTest.Types;

public class AmountPerUom : IRebateCalculator
{
    public CalculateRebateResult CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request)
    {
        CalculateRebateResult rebateResult = new CalculateRebateResult() { Success = false, RebateAmount = 0 };
        if (rebate == null)
        {
            rebateResult.Success = false;
        }
        else if (product == null)
        {
            rebateResult.Success = false;
        }
        else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom))
        {
            rebateResult.Success = false;
        }
        else if (rebate.Amount == 0 || request.Volume == 0)
        {
            rebateResult.Success = false;
        }
        else
        {
            rebateResult.RebateAmount += rebate.Amount * request.Volume;
            rebateResult.Success = true;
        }
        return rebateResult;
    }
}