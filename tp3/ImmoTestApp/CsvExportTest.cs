using System.Collections;

namespace ImmoTestApp;
public class CsvExportTest
{

    public class CsvExportTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                1000,
                new List<MonthlyStatus> {
                    new MonthlyStatus { Month = 1, Paid = 100, Remaining = 1000 },
                    new MonthlyStatus { Month = 2, Paid = 200, Remaining = 900 },
                    new MonthlyStatus { Month = 3, Paid = 300, Remaining = 600 },
                    new MonthlyStatus { Month = 4, Paid = 400, Remaining = 200 },
                    new MonthlyStatus { Month = 5, Paid = 500, Remaining = 0 },
                },
                "1000\n1;100;1000\n2;200;900\n3;300;600\n4;400;200\n5;500;0\n"
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [Theory]
    [ClassData(typeof(CsvExportTestData))]
    public void ShouldPrintCsv(double amount, List<MonthlyStatus> data, string expected)
    {
        Assert.Equal(expected, CsvExport.Export(amount, data));
    }

}
