using Xunit;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Tests;

public class PaymentServiceTests
{
    [Fact]
    public void DefaultParametersReturnsCorrectResult()
    {
        var rbtReq = new CalculateRebateRequest();
        var result = new RebateService(new Data.RebateDataStore(), new Data.ProductDataStore(), rbtReq).Calculate(rbtReq);
        Assert.True(result.Success == false, "Rebate service with default values does not return false");
    }

    [Fact]
    public void FixedRateRebateReturnsSuccess()
    {
        var rbtReq = new CalculateRebateRequest() { ProductIdentifier = "PrdA", RebateIdentifier = "Rbt1", Volume = 5, };
        var rbt = new Rebate() { Identifier = "Rbt1", Incentive = IncentiveType.FixedRateRebate, Amount = 1, Percentage = 10, };
        var prd = new Product() { Id = 1, Identifier = "PrdA", Price = 10.50m, SupportedIncentives = SupportedIncentiveType.FixedRateRebate, Uom = "kg" };
        var result = new RebateService(rbt, prd, rbtReq).Calculate(rbtReq);
        Assert.True(result.Success == true, "Rebate service for product with FixedRateRebate returns true");
    }

    [Fact]
    public void FixedRateRebateCalculatorReturnsCorrectRebateAmount()
    {
        var rbtReq = new CalculateRebateRequest() { ProductIdentifier = "PrdA", RebateIdentifier = "Rbt1", Volume = 5, };
        var rbt = new Rebate() { Identifier = "Rbt1", Incentive = IncentiveType.FixedRateRebate, Amount = 1, Percentage = 10, };
        var prd = new Product() { Id = 1, Identifier = "PrdA", Price = 10.50m, SupportedIncentives = SupportedIncentiveType.FixedRateRebate, Uom = "kg" };
        var result = new RebateService(rbt, prd, rbtReq).Calculate(rbtReq);
        Assert.True(result.RebateAmount == 525, "Rebate service for product with FixedRateRebate returns true");
    }
}