// See https://aka.ms/new-console-template for more information
using ImmoApp;

try {
    var data = Parser.Parse(string.Join(" ", args));

    File.WriteAllText("output.csv", CsvExport.Export(data.Amount, data.GetAllMonthlyStatus().ToList()));

} catch (Exception e) {
    Console.WriteLine(e.Message);
}