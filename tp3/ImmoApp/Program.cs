// See https://aka.ms/new-console-template for more information
using ImmoApp;

try {
    var data = Parser.Parse(string.Join(" ", args));

    Console.WriteLine($"Monthly payment: {data.MonthlyPayment}");

} catch (Exception e) {
    Console.WriteLine(e.Message);
}