using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Products;

public interface IProductProvider
{
    IEnumerable<Product> Products { get; }
}
