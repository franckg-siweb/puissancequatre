namespace ImmoApp;
public class Computation
{

    public static double ComputeMonthlyPayment(double amount, double duration, double rate)
    {
        var monthlyRate = rate / 12;
        return amount * monthlyRate / (1 - Math.Pow(1 + monthlyRate, -duration));
    }

}
