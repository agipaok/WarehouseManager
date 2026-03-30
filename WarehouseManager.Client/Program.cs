using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using WarehouseManager.Client;
using WarehouseManager.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ProductClientService>();
builder.Services.AddScoped<SupplierClientService>();
builder.Services.AddScoped<StockMovementClientService>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
