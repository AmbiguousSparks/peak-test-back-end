namespace PeakInvest.API.Services.Interfaces;

public interface IService
{
    decimal CalculateValue(decimal value, int times);

    string GetName(int id);
}