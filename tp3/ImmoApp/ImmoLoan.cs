namespace ImmoApp;
public class ImmoLoan
{
    public double Amount { get; set; }
    public double Duration { get; set; }
    public double Rate { get; set; }

    public double MonthlyPayment {
        get {
            var monthlyRate = Rate / 100 / 12;
            var divisor = Math.Pow(1 + monthlyRate, Duration) - 1;
            var result = Amount * monthlyRate / divisor + Amount * monthlyRate;
            return Math.Round(result, 0);
        } 
    }

    public double ExpectedTotal {
        get {
            return MonthlyPayment * Duration;
        }
    }

}
