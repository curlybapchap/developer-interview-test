namespace Smartwyre.DeveloperTest.Types;

public interface IIncentiveType
{
    void CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request);
    bool success { get; set; }
    decimal rebateAmount { get; set; }
}