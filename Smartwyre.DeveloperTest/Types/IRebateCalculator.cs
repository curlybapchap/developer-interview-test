namespace Smartwyre.DeveloperTest.Types;

public interface IRebateCalculator
{
    void CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request);
    CalculateRebateResult rebateResult { get; set; }
}