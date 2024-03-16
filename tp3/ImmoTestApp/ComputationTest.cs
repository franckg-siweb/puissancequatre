namespace ImmoTestApp;
public class ComputationTest
{

    [Theory]
    [InlineData(75000, 120, 0.5, 641)]
    [InlineData(100000, 180, 0.8, 590)]
    [InlineData(200000, 240, 1.1, 929)]
    public void ShouldComputeMonthlyPayment(double amount, double duration, double rate, double expected)
    {

        var result = Computation.ComputeMonthlyPayment(new InputData
        {
            Amount = amount,
            Duration = duration,
            Rate = rate
        });

        Assert.Equal(expected, result);

    }

}
