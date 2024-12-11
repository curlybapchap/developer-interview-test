namespace Smartwyre.DeveloperTest.Types;

public class AmountPerUom : IIncentiveType
{
    public void CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request)
    {
        if (rebate == null)
        {
            //success = false;
        }
        else if (product == null)
        {
            //success = false;
        }
        else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom))
        {
            //success = false;
        }
        else if (rebate.Amount == 0 || request.Volume == 0)
        {
            //success = false;
        }
        else
        {
            rebateAmount += rebate.Amount * request.Volume;
            success = true;
        }
    }

    public bool success { get; set; } = false;
    public decimal rebateAmount { get; set; } = 0.0m;
}
