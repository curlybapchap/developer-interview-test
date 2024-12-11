using System;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        var rbtReq = new CalculateRebateRequest();
        var result = new RebateService().Calculate(rbtReq);
        Console.Write($"Rebate calculation with default values is {result.Success}");
    }
}
