using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using QapaqMantenimiento.Client;
using QapaqMantenimiento.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5118") });

builder.Services.AddScoped<ITipoIncidenteService,TipoIncidenteService>();
builder.Services.AddScoped<ISubTipoService, SubTipoService>();

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
