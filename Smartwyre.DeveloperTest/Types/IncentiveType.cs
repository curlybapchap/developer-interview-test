namespace Smartwyre.DeveloperTest.Types;

public enum IncentiveType
{
    FixedRateRebate,
    AmountPerUom,
    FixedCashAmount
}


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

public class FixedRateRebate : IIncentiveType
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
        else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate))
        {
            //success = false;
        }
        else if (rebate.Percentage == 0 || product.Price == 0 || request.Volume == 0)
        {
            success = false;
        }
        else
        {
            rebateAmount += product.Price * rebate.Percentage * request.Volume;
            success = true;
        }
    }

    public bool success { get; set; } = false;
    public decimal rebateAmount { get; set; } = 0.0m;
}

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

public interface IIncentiveType
{
    void CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request);
    bool success { get; set; }
    decimal rebateAmount { get; set; }
}