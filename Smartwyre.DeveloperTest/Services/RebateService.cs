using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        var result = new CalculateRebateResult();

        var rebateAmount = 0m;

        IIncentiveType calculator;

        switch (rebate.Incentive)
        {
            case IncentiveType.FixedCashAmount:
                calculator = new FixedCashAmount();
                calculator.CalculateRebate(rebate, product, request);
                result.Success = calculator.success;
                rebateAmount = calculator.rebateAmount;
                break;

            case IncentiveType.FixedRateRebate:
                calculator = new FixedRateRebate();
                calculator.CalculateRebate(rebate, product, request);
                result.Success = calculator.success;
                rebateAmount = calculator.rebateAmount;
                break;

            case IncentiveType.AmountPerUom:
                calculator = new AmountPerUom();
                calculator.CalculateRebate(rebate, product, request);
                result.Success = calculator.success;
                rebateAmount = calculator.rebateAmount;
                break;
        }

        if (result.Success)
        {
            var storeRebateDataStore = new RebateDataStore();
            storeRebateDataStore.StoreCalculationResult(rebate, rebateAmount);
        }

        return result;
    }


    public RebateService() { }

    public RebateService(RebateDataStore rebateDataStore, ProductDataStore productDataStore, CalculateRebateRequest request)
    {
        this.rebateDataStore = rebateDataStore;
        this.productDataStore = productDataStore;
        this.request = request;

        rebate = rebateDataStore.GetRebate(request.RebateIdentifier);
        product = productDataStore.GetProduct(request.ProductIdentifier);
    }

    public RebateService(Rebate rebate, Product product, CalculateRebateRequest request)
    {
        this.rebate = rebate;
        this.product = product;
        this.request = request;
    }

    private RebateDataStore rebateDataStore;
    private ProductDataStore productDataStore;
    private Rebate rebate;
    private Product product;
    private CalculateRebateRequest request;
}