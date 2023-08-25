using CodeCool.SeasonalProductDiscounter.Model.Discounts;
using CodeCool.SeasonalProductDiscounter.Service.Logger;


namespace CodeCool.SeasonalProductDiscounter.Service.Discounts;

public interface IDiscountProvider
{
    IEnumerable<IDiscount> Discounts { get; }
}

public class DiscountProvider : IDiscountProvider
{
    private readonly ILogger _logger;
    public IEnumerable<IDiscount> Discounts { get; }

    public DiscountProvider(ILogger consoleLogger)
    {
        List<IDiscount> discounts = new List<IDiscount>();

        string[] monthlyDiscountNames = { "Summer Kick-off", "Winter Sale" };
        string[] colorDiscountNames = { "Blue Winter", "Green Spring", "Yellow Summer", "Brown Autumn" };
        string[] seasonalDiscountNames = { "Sale Discount", "Outlet Discount" };
        AddDiscountObjects(monthlyDiscountNames, discounts, 1);
        AddDiscountObjects(colorDiscountNames, discounts, 2);
        AddDiscountObjects(seasonalDiscountNames, discounts, 3);
        Discounts = discounts;
        _logger = consoleLogger;
        _logger.LogInfo("All Discounts have been created!");
    }

    private static void AddDiscountObjects(string[] discountNames, List<IDiscount> discounts, int discountType)
    {
        foreach (var discountName in discountNames)
        {
            IDiscount discountObj = discountType == 1 ? new MonthlyDiscounts(discountName, 10)
                                  : discountType == 2 ? new ColorDiscounts(discountName, 5)
                                  : discountName == "Sale Discount" ? new SeasonalDiscounts(discountName, 10)
                                  : new SeasonalDiscounts(discountName, 20);

            discounts.Add(discountObj);
        }
    } 
}
