namespace Smartwyre.DeveloperTest.Types;

public class FixedRateRebate : IIncentiveType
{
    public void CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request)
    {
        if (rebate == null)
        {
            rebateResult.Success = false;
        }
        else if (product == null)
        {
            rebateResult.Success = false;
        }
        else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate))
        {
            rebateResult.Success = false;
        }
        else if (rebate.Percentage == 0 || product.Price == 0 || request.Volume == 0)
        {
            rebateResult.Success = false;
        }
        else
        {
            rebateResult.RebateAmount += product.Price * rebate.Percentage * request.Volume;
            rebateResult.Success = true;
        }
    }

    public CalculateRebateResult rebateResult { get; set; } = new CalculateRebateResult() { Success = false, RebateAmount = 0 };
}