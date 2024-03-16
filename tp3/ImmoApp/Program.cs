// See https://aka.ms/new-console-template for more information
using ImmoApp;

try {
    var data = Parser.Parse(string.Join(" ", args));

    var monthlyPayment = Computation.ComputeMonthlyPayment(data);

    Console.WriteLine($"Monthly payment: {monthlyPayment}");

} catch (Exception e) {
    Console.WriteLine(e.Message);
}