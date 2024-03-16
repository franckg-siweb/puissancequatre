namespace ImmoTestApp;
public class ComputationTest
{

    [Theory]
    [InlineData(75000, 120, 0.5, 625.00)]
    [InlineData(100000, 180, 0.8, 833.33)]
    [InlineData(200000, 240, 1.1, 1666.67)]
    public void ShouldComputeMonthlyPayment(double amount, double duration, double rate, double expected)
    {

        var result = Computation.ComputeMonthlyPayment(amount, duration, rate);

        Assert.Equal(expected, result);

    }

}
