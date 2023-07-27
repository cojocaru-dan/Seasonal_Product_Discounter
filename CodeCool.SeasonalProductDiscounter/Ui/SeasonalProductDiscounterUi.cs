using System.Collections;
using CodeCool.SeasonalProductDiscounter.Model.Offers;
using CodeCool.SeasonalProductDiscounter.Service.Discounts;
using CodeCool.SeasonalProductDiscounter.Service.Products;

namespace CodeCool.SeasonalProductDiscounter.Ui;

public class SeasonalProductDiscounterUi
{
    private readonly IProductProvider _productProvider;
    private readonly IDiscountProvider _discountProvider;
    private readonly IDiscounterService _discounterService;

    public SeasonalProductDiscounterUi(
        IProductProvider productProvider,
        IDiscountProvider discountProvider,
        IDiscounterService discounterService)
    {
        _productProvider = productProvider;
        _discountProvider = discountProvider;
        _discounterService = discounterService;
    }

    public void Run()
    {
        Console.WriteLine("Welcome to Seasonal Product Discounter!");
        Console.WriteLine();

        PrintCatalog();
        PrintPromotions();

        Console.WriteLine("Enter a date to see which products are discounted on that date:");
        var date = GetDate();
        Console.WriteLine();

        PrintOffers(date);
    }

    private void PrintCatalog()
    {
        Console.WriteLine("Current product catalog (without any discounts):");
        PrintEnumerable(_productProvider.Products);
        Console.WriteLine();
    }

    private void PrintPromotions()
    {
        Console.WriteLine("This year's promotions:");
        PrintEnumerable(_discountProvider.Discounts);
        Console.WriteLine();
    }

    private void PrintOffers(DateTime date)
    {
        var discounted = GetOffers(date);
        PrintEnumerable(discounted);
    }

    private List<Offer> GetOffers(DateTime date)
    {
        List<Offer> discounted = new();
        foreach (var product in _productProvider.Products)
        {
            var offer = _discounterService.GetOffer(product, date);
            if (offer.Discounts.Any())
            {
                discounted.Add(offer);
            }
        }

        return discounted;
    }

    private static DateTime GetDate()
    {
        string? input = null;
        DateTime date;

        while (!DateTime.TryParse(input, out date))
        {
            if (input != null)
            {
                Console.WriteLine("Invalid date!");
            }

            input = Console.ReadLine();
        }

        return date;
    }

    private static void PrintEnumerable(IEnumerable enumerable)
    {
        foreach (var element in enumerable)
        {
            Console.WriteLine(element);
        }
    }
}
