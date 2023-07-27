
using CodeCool.SeasonalProductDiscounter.Model.Enums;

namespace CodeCool.SeasonalProductDiscounter.Model.Products;

public record Product(string Name, Color Color, Season Season, double Price)
{
    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, " +
               $"{nameof(Color)}: {Color}, " +
               $"{nameof(Season)}: {Season}, " +
               $"{nameof(Price)}: {Price}";
    }
}
