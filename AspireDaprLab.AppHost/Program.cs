var builder = DistributedApplication.CreateBuilder(args);

var orderService = builder.AddProject<Projects.OrderService>("orderservice")
    .WithDaprSidecar();

var checkout = builder.AddProject<Projects.CheckoutService>("checkout")
    .WithDaprSidecar()
    .WithReference(orderService);

builder.Build().Run();
