// Andrea Maria Castronovo
// 5°I
// 22-05-2024
// Progetto stazione meteo

using BlazorApp_StazioneMeteo.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorApp_StazioneMeteo.Repository.Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Aggiunto il servizio per poterlo usare nei componenti razor.
var connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:MeteoScuola");

builder.Services.AddScoped<StazioneDB>(
    sp => new StazioneDB(connectionString)
);
builder.Services.AddScoped<RilevamentoDB>(
    sp => new RilevamentoDB(connectionString)
);
builder.Services.AddScoped<GrandezzaFisicaDB>(
    sp => new GrandezzaFisicaDB(connectionString)
);
builder.Services.AddScoped<SensoreDB>(
    sp => new SensoreDB(connectionString)
);
builder.Services.AddScoped<SensoriInstallatiDB>(
    sp => new SensoriInstallatiDB(connectionString)
);


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
