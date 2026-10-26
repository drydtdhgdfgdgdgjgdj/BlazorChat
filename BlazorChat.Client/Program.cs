using BlazorChat.Client;
using BlazorChat.Sdk;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("TalkApi", options =>
{
    options.BaseAddress = new Uri("https://talkapi2.azurewebsites.net");
});

//Register Sdk Services
builder.Services.AddScoped<ChatChannelService>();
builder.Services.AddScoped<ChatMessageService>();

await builder.Build().RunAsync();
