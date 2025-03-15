using Dapr.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDaprClient();

builder.AddServiceDefaults();

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseHttpsRedirection();

app.MapPost("/checkout", async (Order order, DaprClient daprClient) =>
{
    var result = await daprClient.InvokeMethodAsync<Order, decimal>("orderservice", "process", order);

    return Results.Ok(new { Message = $"Order {order.Id} processed. Total order value: ${result}" });
});

app.Run();

public record Order(int Id, List<OrderItem> Items);
public record OrderItem(string Name, decimal Price, int Qty);