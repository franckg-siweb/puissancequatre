namespace ImmoApp;
public class Parser
{

    public static int MIN_AMOUNT = 50000;
    public static int MIN_DURATION = 108;
    public static int MAX_DURATION = 300;


    public static Dictionary<string, double> Parse(string input)
    {
        var parts = input.Split(' ');

        if (parts.Length != 3)
        {
            throw new ArgumentException("Invalid input");
        }

        if (!double.TryParse(parts[0], out double amount))
        {
            throw new ArgumentException("Invalid amount");
        }

        if (amount < MIN_AMOUNT)
        {
            throw new ArgumentException("Amount should be at least " + MIN_AMOUNT);
        }

        if (!double.TryParse(parts[1], out double duration))
        {
            throw new ArgumentException("Invalid duration");
        }

        if (duration < MIN_DURATION || duration > MAX_DURATION)
        {
            throw new ArgumentException("Duration should be between " + MIN_DURATION + " and " + MAX_DURATION);
        }

        if (!double.TryParse(parts[2], out double rate))
        {
            throw new ArgumentException("Invalid rate");
        }

        return new Dictionary<string, double>
        {
            { "Amount", amount },
            { "Duration", duration },
            { "Rate", rate }
        };
    }

}
