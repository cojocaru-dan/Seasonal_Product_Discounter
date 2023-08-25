using CodeCool.SeasonalProductDiscounter.Model.Enums;

namespace CodeCool.SeasonalProductDiscounter.Extensions;

public static class SeasonExtensions
{
    private static readonly Dictionary<Season, Month[]> SeasonsToMonths = new()
    {
        { Season.Spring, new[] { Month.March, Month.April, Month.May } },
        { Season.Summer, new[] { Month.June, Month.July, Month.August } },
        { Season.Autumn, new[] { Month.September, Month.October, Month.November } },
        { Season.Winter, new[] { Month.December, Month.January, Month.February } }
    };

    private static readonly Season[] Seasons = SeasonsToMonths.Keys.ToArray();

    public static Season Shift(this Season season, int shift)
    {
        int seasonNumber = ((int) season + shift) % 4;
        seasonNumber = seasonNumber == -1 ? 3 : seasonNumber;
        return (Season) seasonNumber;
    }

    public static bool Contains(this Season season, DateTime date)
    {
        return SeasonsToMonths[season].Any(month => month.ToString() == date.ToString("MMMM"));
    }
}
