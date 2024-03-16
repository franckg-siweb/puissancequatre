namespace ImmoTestApp;

public class ParserTests
{

    private static int MIN_AMOUNT = 50000;
    private static int MIN_DURATION = 108;
    private static int MAX_DURATION = 300;


    [Theory]

    [InlineData("60300 128 0.35",  6300, 128, 0.35)]
    [InlineData("50000 108 1.23",  50000, 108, 1.23)]
    [InlineData("128250 300 0.67",  128250, 300, 0.67)]
    
    public void ShouldParseInputWhenCorrect(string input, double amount, double duration, double rate)
    {

        var result = Parser.Parse(input);

        Assert.Equal(amount, result.Amount);
        Assert.Equal(duration, result.Duration);
        Assert.Equal(rate, result.Rate);

    }

    [Theory]
    [InlineData("0 128 1")]
    [InlineData("-12 128 1")]
    [InlineData("49999 128 1")]
    public void ShouldThrowIfAmountInsufficient(string input)
    {

        Assert.Throws<ArgumentException>(() => Parser.Parse(input));

    }

    [Theory]
    [InlineData("5-0000 128 1")]
    [InlineData("50000 p 1")]
    [InlineData("50000 128 one")]
    [InlineData("50000$ 128, 1")]

    public void ShouldThrowIfParamIsNotANumber(string input)
    {

        Assert.Throws<ArgumentException>(() => Parser.Parse(input));

    }

    [Theory]
    [InlineData("50000 128 1 1")]
    [InlineData("50000,128,1")]
    [InlineData("50000 128")]
    [InlineData("50000 128 1 1 1")]
    [InlineData("")]
    public void ShouldThrowIfNot3Params(string input)
    {
        Assert.Throws<ArgumentException>(() => Parser.Parse(input));
    }
    
    [Theory]
    [InlineData("50000 107 1")]
    [InlineData("50000 301 1")]
    [InlineData("50000 0 1")]
    [InlineData("50000 -1 0")]
    public void ShouldThrowIfDurationNotInRange(string input)
    {
        Assert.Throws<ArgumentException>(() => Parser.Parse(input));
    }

}