namespace ImmoApp;
public class Computation
{

    public static double ComputeMonthlyPayment(double amount, double duration, double rate)
    {
        var monthlyRate = rate / 100 / 12;
        var divisor = Math.Pow(1 + monthlyRate, duration) - 1;
        var result = amount * monthlyRate / divisor + amount * monthlyRate;
        return Math.Round(result, 0);
    }

}
