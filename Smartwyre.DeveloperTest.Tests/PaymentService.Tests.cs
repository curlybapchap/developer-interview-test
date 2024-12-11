using Xunit;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Data;

namespace Smartwyre.DeveloperTest.Tests;

public class PaymentServiceTests
{
    [Fact]
    public void DefaultParametersReturnsCorrectResult()
    {
        var rbtReq = new CalculateRebateRequest();
        var result = new RebateService(new RebateDataStore(), new ProductDataStore()).Calculate(rbtReq);
        Assert.True(result.Success == false, "Rebate service with default values does not return false");
    }
}