using System.Text;

namespace ImmoApp;
public class CsvExport
{

    public static string Export(double amount, List<MonthlyStatus> data)
    {
        var sb = new StringBuilder();
        sb.AppendLine(amount.ToString());
        foreach (var status in data)
        {
            sb.AppendLine(status.Month + ";" + status.Paid + ";" + status.Remaining);
        }
        return sb.ToString();
    }
}
