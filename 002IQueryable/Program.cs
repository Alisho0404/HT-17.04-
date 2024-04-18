using _001GroupBy.Data;

await using var dataContext = new DataContext();


Console.WriteLine("Good look  😊😊😊");


//1
//Получить все заказы клиента с id=1, отгруппированные по сумме заказа
//Get all customer orders with id=1, grouped by order amount
var cliet1 = dataContext.Orders
    .Where(o => o.CustomerId == 1)
    .Select(group => new
    {
        Customer = group.Customer!.Name,
        TotalAmount = group.OrderItems!.Sum(oi => oi.Price)
    })
    .OrderBy(result => result.TotalAmount);
foreach (var item in cliet1)
{
    Console.WriteLine($"Customer:{item.Customer} Amount:{item.TotalAmount}");
}
Console.WriteLine();
//2
//Получите все заказы клиентов с ID = 1, сгруппированные по количеству товаров в заказе:
//Get all customer orders with ID = 1, grouped by the number of goods in the order
var cliet2 = dataContext.Orders
    .Where(o => o.CustomerId == 1)
    .Select(group => new
    {
        Customer = group.Customer!.Name,
        Count = group.OrderItems!.Count()
    })
    .OrderBy(result => result.Count);
foreach (var item in cliet2)
{
    Console.WriteLine($"Customer:{item.Customer} OrderCount:{item.Count}");
}
Console.WriteLine();
//3
//Получить все заказы клиента с id=2, отгруппированные по данным
//Get all customer orders with id=2, grouped by data 
var client3 = dataContext.Orders
    .Where(c => c.Id == 2)
    .GroupBy(o => o.OrderDate)
    .Select(g => new
    {
        OrderDate = g.Key,
        Id = g.Select(o => o.Customer!.Name)
    });
foreach (var item in client3)
{
    Console.WriteLine(item.OrderDate);
}