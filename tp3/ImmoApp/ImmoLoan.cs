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

    public MonthlyStatus GetMonthlyStatus(int month)
    {
        
        if (month < 1 || month > Duration)
        {
            throw new ArgumentOutOfRangeException("Invalid month, should be between 1 and " + Duration);
        }

        var paid = MonthlyPayment * month;

        return new MonthlyStatus() {
            Month = month,
            Paid = paid,
            Remaining = ExpectedTotal - paid
        };

    }

    public MonthlyStatus[] GetAllMonthlyStatus()
    {
        var result = new MonthlyStatus[(int)Duration];
        for (int i = 1; i <= Duration; i++)
        {
            result[i - 1] = GetMonthlyStatus(i);
        }
        return result;
    }

}
