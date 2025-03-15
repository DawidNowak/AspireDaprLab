var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseHttpsRedirection();

app.MapPost("/process", (Order order) =>
{
    return order.Items.Sum(i => i.Price * i.Qty);
});

app.Run();

public record Order(int Id, List<OrderItem> Items);
public record OrderItem(string Name, decimal Price, int Qty);