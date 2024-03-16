namespace ImmoTestApp;

public class ParserTests
{
    [Theory]
    [InlineData("60300 48 0,35",  6300, 48, 0.35)]
    
    public void ShouldParseInputToDictionnary(string input, double amount, double duration, double rate)
    {

    }

    [Theory]
    [InlineData("0 1 1")]
    [InlineData("-12 1 1")]
    [InlineData("49999 1 1")]
    public void ShouldThrowIfAmountInsufficient(string input)
    {

    }


}