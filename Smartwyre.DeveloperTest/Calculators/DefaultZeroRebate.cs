namespace Smartwyre.DeveloperTest.Types;

public class DefaultZeroRebate : IRebateCalculator
{
    public CalculateRebateResult CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request)
    {
        return new CalculateRebateResult() { Success = false, RebateAmount = 0 };
    }
}