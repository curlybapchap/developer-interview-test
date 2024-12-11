using Xunit;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Tests;

public class PaymentServiceTests
{
    [Fact]
    public void Test1()
    {
        var rbtReq = new CalculateRebateRequest();
        var result = new RebateService().Calculate(rbtReq);
        Assert.True(result.Success == false, "Rebate service with default values does not return false");
    }
}