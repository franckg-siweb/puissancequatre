using System.Collections;

namespace ImmoTestApp;

public class ImmoLoanTestData {
    public static ImmoLoan Data1 = new ImmoLoan { 
        Amount = 75000, 
        Duration = 120, 
        Rate = 0.5, 
    };

    public static ImmoLoan Data2 = new ImmoLoan { 
        Amount = 100000, 
        Duration = 180, 
        Rate = 0.8, 
    };

    public static ImmoLoan Data3 = new ImmoLoan { 
        Amount = 200000, 
        Duration = 240, 
        Rate = 1.1, 
    };

}

public class ImmoLoanTest
{

    public class ImmoLoanMonthlyPaymentTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                ImmoLoanTestData.Data1, 641
            };
            yield return new object[] {
                ImmoLoanTestData.Data2, 590
            };   
            yield return new object[] {
                ImmoLoanTestData.Data3, 929
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [Theory]
    [ClassData(typeof(ImmoLoanMonthlyPaymentTestData))]
    public void ShouldComputeMonthlyPayment(ImmoLoan data, double expected)
    {
        Assert.Equal(expected, data.MonthlyPayment);
    }


    public class ImmoLoanExpectedTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                ImmoLoanTestData.Data1, 76920
            };
            yield return new object[] {
                ImmoLoanTestData.Data2, 106200
            };   
            yield return new object[] {
                ImmoLoanTestData.Data3, 222960
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    [Theory]
    [ClassData(typeof(ImmoLoanExpectedTestData))]
    public void ShouldComputeExpected(ImmoLoan data, double expected)
    {
        Assert.Equal(expected, data.ExpectedTotal);
    }


    public class ImmoLoanMonthlyStatusTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                ImmoLoanTestData.Data1, new MonthlyStatus { 
                    Month = 1, 
                    Paid = 641, 
                    Remaining = 76279
                }
            };
            yield return new object[] {
                ImmoLoanTestData.Data2, new MonthlyStatus { 
                    Month = 100, 
                    Paid = 59000, 
                    Remaining = 47200 
                }
            };   
            yield return new object[] {
                ImmoLoanTestData.Data3, new MonthlyStatus { 
                    Month = 240, 
                    Paid = 222960,
                    Remaining = 0,
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [Theory]
    [ClassData(typeof(ImmoLoanMonthlyStatusTestData))]
    public void ShouldGetMonthlyStatus(ImmoLoan data, MonthlyStatus expected)
    {
        var result = data.GetMonthlyStatus(expected.Month);
        Assert.Equal(expected.Month, result.Month);
        Assert.Equal(expected.Paid, result.Paid);
        Assert.Equal(expected.Remaining, result.Remaining);
    }


    [Theory]
    [ClassData(typeof(ImmoLoanMonthlyStatusTestData))]
    public void ShouldGetAllMonthlyStatus(ImmoLoan data, MonthlyStatus expected)
    {
        // var results = data.GetAllMonthlyStatus();
        // var result = results[expected.Month - 1];
        // Assert.Equal(expected.Month, result.Month);
        // Assert.Equal(expected.Paid, result.Paid);
        // Assert.Equal(expected.Remaining, result.Remaining);
    }


    public class ImmoLoanInvalidMonthlyStatusTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                ImmoLoanTestData.Data1, -1
            };
            yield return new object[] {
                ImmoLoanTestData.Data2, 181
            };   
            yield return new object[] {
                ImmoLoanTestData.Data3, int.MaxValue
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [Theory]
    [ClassData(typeof(ImmoLoanInvalidMonthlyStatusTestData))]
    public void ShouldNotGetMonthlyStatusWithInvalidMonth(ImmoLoan data, int month)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => data.GetMonthlyStatus(month));
    }

}
