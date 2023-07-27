using CodeCool.SeasonalProductDiscounter.Model.Discounts;

namespace CodeCool.SeasonalProductDiscounter.Service.Discounts;

public interface IDiscountProvider
{
    IEnumerable<IDiscount> Discounts { get; }
}
