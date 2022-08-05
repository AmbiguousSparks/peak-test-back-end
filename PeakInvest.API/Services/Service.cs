using PeakInvest.API.Services.Interfaces;

namespace PeakInvest.API.Services;

public class Service : IService
{
    private static readonly Dictionary<int, string> Names = new()
    {
        {1, "João"},
        {2, "Maria"},
        {3, "Ana"},
        {4, "Carlos"}
    };

    public decimal CalculateValue(decimal value, int times)
    {
        var result = times * value;

        return result + result * 0.05m;
    }

    public string GetName(int id)
    {
        return !Names.ContainsKey(id) ? string.Empty : Names[id];
    }
}