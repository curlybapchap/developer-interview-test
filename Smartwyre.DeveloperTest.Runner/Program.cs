using System;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {

        Console.Write("Please enter volume: ");
        string userInput = Console.ReadLine();

        if (!Decimal.TryParse(userInput, out decimal volume))
            Console.WriteLine($"Volume must be a decimal value");

        Console.Write("Please enter percent: ");
        userInput = Console.ReadLine();
        if (!Decimal.TryParse(userInput, out decimal perCent))
            Console.WriteLine($"Percent must be a decimal value");

        Console.Write("Please enter price: ");
        userInput = Console.ReadLine();
        if (!Decimal.TryParse(userInput, out decimal price))
            Console.WriteLine($"Price must be a decimal value");

        Console.Write("Please enter amount: ");
        userInput = Console.ReadLine();
        if (!Decimal.TryParse(userInput, out decimal amount))
            Console.WriteLine($"Amount must be a decimal value");

        Console.Write("Select incentive type: 0. Fixed Rate Rebate 1. Amount per UOM 2. Fixed Cash Amount");
        userInput = Console.ReadLine();

        IncentiveType incentiveType = IncentiveType.DefaultZeroRebate;
        if (int.TryParse(userInput, out int choice))
        {
            incentiveType = (IncentiveType)choice;
        }
        else
        {
            Console.WriteLine("Please start again and select 0, 1 or 2'. Default zero rebate applied for now.");
        }

        Console.Write("Select product supported incentive type: 1. Fixed Rate Rebate 2. Amount per UOM 3. Fixed Cash Amount");
        userInput = Console.ReadLine();

        SupportedIncentiveType suppIncentiveType = SupportedIncentiveType.AmountPerUom;
        if (int.TryParse(userInput, out int choiceSupInc))
        {
            suppIncentiveType = (SupportedIncentiveType)choiceSupInc;
        }
        else
        {
            Console.WriteLine("Please enter 0, 1 or 2'. FixedRateRebate applied for now");
        }

        var rbtReq = new CalculateRebateRequest() { Volume = volume };
        var result = new RebateService(new Rebate() { Incentive = incentiveType, Percentage = perCent, Amount = amount },
        new Product() { Price = price, SupportedIncentives = suppIncentiveType },
        new CalculateRebateRequest()).Calculate(rbtReq);

        Console.Write($"Rebate calculation with successful?  {result.Success}");
        Console.Write($"Rebate amount = {result.RebateAmount}");
    }
}