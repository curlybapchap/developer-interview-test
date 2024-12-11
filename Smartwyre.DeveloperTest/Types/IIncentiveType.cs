namespace Smartwyre.DeveloperTest.Types;

public interface IIncentiveType
{
    void CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request);
    CalculateRebateResult rebateResult { get; set; }
}