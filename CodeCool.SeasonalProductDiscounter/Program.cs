using CodeCool.SeasonalProductDiscounter.Service.Products;
using CodeCool.SeasonalProductDiscounter.Service.Discounts;
using CodeCool.SeasonalProductDiscounter.Ui;
using CodeCool.SeasonalProductDiscounter.Service.Logger;



namespace CodeCool.SeasonalProductDiscounter;

class Program
{
    static void Main(string[] args)
    {
        ILogger consoleLogger = new ConsoleLogger();
        IProductProvider productProvider = new ProductProvider(consoleLogger);
        IDiscountProvider discountProvider = new DiscountProvider(consoleLogger);
        IDiscounterService discounterService = new DiscounterService();

        SeasonalProductDiscounterUi seasonalProductDiscounterUi = new SeasonalProductDiscounterUi(productProvider, discountProvider, discounterService, consoleLogger);
        seasonalProductDiscounterUi.Run();
    }
    
}