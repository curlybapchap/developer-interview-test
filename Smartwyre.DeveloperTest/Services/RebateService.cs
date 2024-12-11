using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        IRebateCalculator calculator = rebate.RebateCalculator;
        calculator.CalculateRebate(rebate, product, request);
        var result = calculator.rebateResult;

        if (result.Success)
        {
            var storeRebateDataStore = new RebateDataStore();
            storeRebateDataStore.StoreCalculationResult(rebate, result.RebateAmount);
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