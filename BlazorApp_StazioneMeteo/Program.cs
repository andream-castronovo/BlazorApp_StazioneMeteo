// Andrea Maria Castronovo
// 5°I
// 11-05-2024
// Progetto stazione meteo

using BlazorApp_StazioneMeteo.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Aggiunto il servizio per poterlo usare nei componenti razor.
var connectionString =
builder.Configuration.GetValue<string>("ConnectionStrings:Northwind");
builder.Services.AddScoped<Stazione>(
sp => new Stazione(connectionString));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
