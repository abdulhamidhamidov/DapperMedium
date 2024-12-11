

using Infrastructure.RequestService;

Requests requests = new Requests();

foreach (var a in requests.GetUserTotalAmounts())
{
    Console.WriteLine(a.Id+" "+a.Address+" "+a.Email+" "+a.Phone+" "+a.Username+" "+a.FirstName+" "+a.Lastname+" "+a.BirthDate+" "+a.TotalAmount);
}
