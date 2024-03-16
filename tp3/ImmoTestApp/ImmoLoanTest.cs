namespace ImmoTestApp;
public class ImmoLoanTest
{

    [Theory]
    [InlineData(75000, 120, 0.5, 641)]
    [InlineData(100000, 180, 0.8, 590)]
    [InlineData(200000, 240, 1.1, 929)]
    public void ShouldComputeMonthlyPayment(double amount, double duration, double rate, double expected)
    {

        var data = new ImmoLoan
        {
            Amount = amount,
            Duration = duration,
            Rate = rate
        };

        Assert.Equal(expected, data.MonthlyPayment);

    }

}
