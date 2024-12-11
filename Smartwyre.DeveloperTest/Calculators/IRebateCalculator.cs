namespace Smartwyre.DeveloperTest.Types;

public interface IRebateCalculator
{
    CalculateRebateResult CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request);
}