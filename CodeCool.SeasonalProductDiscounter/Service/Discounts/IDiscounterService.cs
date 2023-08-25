using CodeCool.SeasonalProductDiscounter.Model.Offers;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Model.Discounts;

namespace CodeCool.SeasonalProductDiscounter.Service.Discounts;

public interface IDiscounterService
{
    Offer GetOffer(Product product, DateTime date, IDiscountProvider discountProvider);
}

public class DiscounterService : IDiscounterService
{
    public Offer GetOffer(Product product, DateTime date, IDiscountProvider discountProvider)
    {
        List<IDiscount> applicableDiscounts = new List<IDiscount>();

        foreach (var discount in discountProvider.Discounts)
        {
            if (discount.Accepts(product, date))
            {
                applicableDiscounts.Add(discount);
            }
        }
        double priceWithDiscounts = CalculatePriceWithDiscounts(product, applicableDiscounts);
        return new Offer(product, date, applicableDiscounts, priceWithDiscounts);
    }

    private static double CalculatePriceWithDiscounts(Product product, List<IDiscount> applicableDiscounts)
    {
        double price = product.Price;
        foreach (var applicableDisc in applicableDiscounts)
        {
            price -= (((double) applicableDisc.Rate / (double) 100) * product.Price);
        }
        return price;
    }
}
