namespace ImmoApp;
public class Computation
{

    public static double ComputeMonthlyPayment(InputData data)
    {
        var monthlyRate = data.Rate / 100 / 12;
        var divisor = Math.Pow(1 + monthlyRate, data.Duration) - 1;
        var result = data.Amount * monthlyRate / divisor + data.Amount * monthlyRate;
        return Math.Round(result, 0);
    }

}
