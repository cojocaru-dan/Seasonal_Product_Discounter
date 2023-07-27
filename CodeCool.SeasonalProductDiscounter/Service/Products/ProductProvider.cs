using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Products;

public class ProductProvider : IProductProvider
{
    public IEnumerable<Product> Products { get; }

    public ProductProvider()
    {
        Products = GetProducts();
    }

    private static IEnumerable<Product> GetProducts()
    {
        return new List<Product>
        {
            new("Yellow skirt", Color.Yellow, Season.Spring, 15.00),
            new("Blue skirt", Color.Blue, Season.Spring, 15.00),
            new("Red T-Shirt", Color.Red, Season.Summer, 10.00),
            new("Brown T-Shirt", Color.Brown, Season.Summer, 10.00),
            new("Brown jacket", Color.Brown, Season.Autumn, 40.00),
            new("Violet shirt", Color.Violet, Season.Autumn, 30.00),
            new("Blue jacket", Color.Blue, Season.Autumn, 40.00),
            new("Blue hat", Color.Blue, Season.Winter, 10.00),
            new("Pink hat", Color.Pink, Season.Winter, 10.00),
            new("Red gloves", Color.Red, Season.Winter, 8.00),
            new("Yellow gloves", Color.Yellow, Season.Winter, 8.00)
        };
    }
}
