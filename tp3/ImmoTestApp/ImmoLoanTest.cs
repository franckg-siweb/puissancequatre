using System.Collections;

namespace ImmoTestApp;

public class ImmoLoanTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] {
            new ImmoLoan { 
            Amount = 75000, 
            Duration = 120, 
            Rate = 0.5, 
        }, 641
        };
        yield return new object[] {
            new ImmoLoan { 
            Amount = 100000, 
            Duration = 180, 
            Rate = 0.8, 
        }, 590
        };   

         yield return new object[] {
            new ImmoLoan { 
            Amount = 200000, 
            Duration = 240, 
            Rate = 1.1, 
        }, 929
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class ImmoLoanTest
{

    [Theory]
    [ClassData(typeof(ImmoLoanTestData))]
    public void ShouldComputeMonthlyPayment(ImmoLoan data, double expected)
    {
        Assert.Equal(expected, data.MonthlyPayment);
    }


}
