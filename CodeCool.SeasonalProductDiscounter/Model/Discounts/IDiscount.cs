using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Extensions;

namespace CodeCool.SeasonalProductDiscounter.Model.Discounts;

public interface IDiscount
{
    bool Accepts(Product product, DateTime date);

    string Name { get; }

    int Rate { get; }
}

public record MonthlyDiscounts(string Name, int Rate) : IDiscount
{
    public bool Accepts(Product product, DateTime date)
    {
        int actualMonthNumber = date.Month;

        if (actualMonthNumber == 2 && Name == "Winter Sale") return true;
        else if ((actualMonthNumber == 6 || actualMonthNumber == 7) && Name == "Summer Kick-off") return true;
        return false;
    }

    public override string ToString() => $"Monthly Discount {Name} {Rate}%";
}

public record ColorDiscounts(string Name, int Rate) : IDiscount
{
    public bool Accepts(Product product, DateTime date)
    {
        int[] winterMonths = { 12, 1, 2 };
        int[] springMonths = { 3, 4, 5 };
        int[] summerMonths = { 6, 7, 8 };
        int[] autumnMonths = { 9, 10, 11 };

        int actualMonthNumber = date.Month;
        if (product.Color == Color.Blue && winterMonths.Any(month => month == actualMonthNumber) && Name == "Blue Winter") return true;
        else if (product.Color == Color.Green && springMonths.Any(month => month == actualMonthNumber) && Name == "Green Spring") return true;
        else if (product.Color == Color.Yellow && summerMonths.Any(month => month == actualMonthNumber) && Name == "Yellow Summer") return true;
        else if (product.Color == Color.Brown && autumnMonths.Any(month => month == actualMonthNumber) && Name == "Brown Autumn") return true;
        return false;
    }

    public override string ToString() => $"Color Discount {Name} {Rate}%";

}

public record SeasonalDiscounts(string Name, int Rate) : IDiscount
{
    public bool Accepts(Product product, DateTime date)
    {
        Season favoredSeason = product.Season;
        Season actualSeason = Season.Winter;

        int[] winterMonths = { 12, 1, 2 };
        int[] springMonths = { 3, 4, 5 };
        int[] summerMonths = { 6, 7, 8 };
        int[] autumnMonths = { 9, 10, 11 };

        int actualMonthNumber = date.Month;
        if (winterMonths.Any(month => month == actualMonthNumber)) actualSeason = Season.Winter;
        else if (springMonths.Any(month => month == actualMonthNumber)) actualSeason = Season.Spring;
        else if (summerMonths.Any(month => month == actualMonthNumber)) actualSeason = Season.Summer;
        else if (autumnMonths.Any(month => month == actualMonthNumber)) actualSeason = Season.Autumn;
        
        if ((favoredSeason.Shift(1) == actualSeason || favoredSeason.Shift(-1) == actualSeason) && Name == "Sale Discount") return true;
        else if (favoredSeason.Shift(2) == actualSeason && Name == "Outlet Discount") return true;
        return false;
    }

    public override string ToString() => $"Seasonal Discount {Name} {Rate}%";

}