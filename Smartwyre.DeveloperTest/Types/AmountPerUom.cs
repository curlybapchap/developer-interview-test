namespace Smartwyre.DeveloperTest.Types;

public class AmountPerUom : IIncentiveType
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
    }

    public CalculateRebateResult rebateResult { get; set; } = new CalculateRebateResult() { Success = false, RebateAmount = 0 };
}