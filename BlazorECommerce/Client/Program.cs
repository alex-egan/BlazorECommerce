global using BlazorECommerce.Shared;
global using System.Net.Http.Json;
global using Microsoft.AspNetCore.Authorization;
global using BlazorECommerce.Client.Services.ProductService;
global using BlazorECommerce.Client.Services.CategoryService;
global using BlazorECommerce.Client.Services.CartService;
global using BlazorECommerce.Client.Services.AuthService;
global using BlazorECommerce.Client.Services.OrderService;
global using BlazorECommerce.Client.Services.AddressService;
global using BlazorECommerce.Client.Services.ProductTypeService;
global using Microsoft.AspNetCore.Components.Authorization;
using BlazorECommerce.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
