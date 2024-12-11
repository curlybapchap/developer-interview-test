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
        var rbt = new Rebate() { Identifier = "Rbt1", Incentive = IncentiveType.FixedRateRebate, Percentage = 10, };
        var prd = new Product() { Id = 1, Identifier = "PrdA", Price = 10m, SupportedIncentives = SupportedIncentiveType.FixedRateRebate, Uom = "kg" };
        var result = new RebateService(rbt, prd, rbtReq).Calculate(rbtReq);
        Assert.True(result.Success == true, "Rebate service for product with FixedRateRebate returns true");
    }

    [Fact]
    public void FixedRateRebateNonSupportedIncentiveUnsuccessful()
    {
        var rbtReq = new CalculateRebateRequest() { ProductIdentifier = "PrdA", RebateIdentifier = "Rbt1", Volume = 5, };
        var rbt = new Rebate() { Identifier = "Rbt1", Incentive = IncentiveType.FixedRateRebate, Percentage = 10, };
        var prd = new Product() { Id = 1, Identifier = "PrdA", Price = 10m, SupportedIncentives = SupportedIncentiveType.AmountPerUom, Uom = "kg" };
        var result = new RebateService(rbt, prd, rbtReq).Calculate(rbtReq);
        Assert.True(result.Success == false, "Product with unsupported incentive returns successful rebate");
    }

    [Fact]
    public void FixedRateRebateWithZeroVolumeUnsuccessful()
    {
        var rbtReq = new CalculateRebateRequest() { ProductIdentifier = "PrdA", RebateIdentifier = "Rbt1", Volume = 0, };
        var rbt = new Rebate() { Identifier = "Rbt1", Incentive = IncentiveType.FixedRateRebate, Percentage = 10, };
        var prd = new Product() { Id = 1, Identifier = "PrdA", Price = 10m, SupportedIncentives = SupportedIncentiveType.AmountPerUom, Uom = "kg" };
        var result = new RebateService(rbt, prd, rbtReq).Calculate(rbtReq);
        Assert.True(result.Success == false, "Product with zero volume returns successful rebate");
    }

    [Fact]
    public void FixedRateRebateWithZeroPriceUnsuccessful()
    {
        var rbtReq = new CalculateRebateRequest() { ProductIdentifier = "PrdA", RebateIdentifier = "Rbt1", Volume = 5, };
        var rbt = new Rebate() { Identifier = "Rbt1", Incentive = IncentiveType.FixedRateRebate, Percentage = 10, };
        var prd = new Product() { Id = 1, Identifier = "PrdA", Price = 0, SupportedIncentives = SupportedIncentiveType.AmountPerUom, Uom = "kg" };
        var result = new RebateService(rbt, prd, rbtReq).Calculate(rbtReq);
        Assert.True(result.Success == false, "Product with zero price returns successful rebate");
    }

    [Fact]
    public void FixedRateRebateCalculatorReturnsCorrectRebateAmount()
    {
        var rbtReq = new CalculateRebateRequest() { ProductIdentifier = "PrdA", RebateIdentifier = "Rbt1", Volume = 5, };
        var rbt = new Rebate() { Identifier = "Rbt1", Incentive = IncentiveType.FixedRateRebate, Percentage = 10, };
        var prd = new Product() { Id = 1, Identifier = "PrdA", Price = 10, SupportedIncentives = SupportedIncentiveType.FixedRateRebate, Uom = "kg" };
        var result = new RebateService(rbt, prd, rbtReq).Calculate(rbtReq);
        Assert.True(result.RebateAmount == 500, $"FixedRateRebate returned {result.RebateAmount}, expected 525");
    }

    [Fact]
    public void AmountPerUomCalculatorReturnsCorrectRebateAmount()
    {
        var rbtReq = new CalculateRebateRequest() { ProductIdentifier = "PrdA", RebateIdentifier = "Rbt1", Volume = 5, };
        var rbt = new Rebate() { Identifier = "Rbt1", Incentive = IncentiveType.AmountPerUom, Amount = 20, };
        var prd = new Product() { Id = 1, Identifier = "PrdA", Price = 10, SupportedIncentives = SupportedIncentiveType.AmountPerUom, Uom = "kg" };
        var result = new RebateService(rbt, prd, rbtReq).Calculate(rbtReq);
        Assert.True(result.RebateAmount == 100, $"AmountPerUom Rebate returned {result.RebateAmount}, expected 525");
    }

    [Fact]
    public void FixedCashAmountCalculatorReturnsCorrectRebateAmount()
    {
        var rbtReq = new CalculateRebateRequest() { ProductIdentifier = "PrdA", RebateIdentifier = "Rbt1", Volume = 5, };
        var rbt = new Rebate() { Identifier = "Rbt1", Incentive = IncentiveType.FixedCashAmount, Amount = 33 };
        var prd = new Product() { Id = 1, Identifier = "PrdA", Price = 10, SupportedIncentives = SupportedIncentiveType.FixedCashAmount, Uom = "kg" };
        var result = new RebateService(rbt, prd, rbtReq).Calculate(rbtReq);
        Assert.True(result.RebateAmount == 33, $"FixedCashAmount Rebate returned {result.RebateAmount}, expected 525");
    }
}