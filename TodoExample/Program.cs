using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TodoExample.Data;
using TodoExample.Data.Models;
using TodoExample.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddAntDesign();
builder.Services.AddOracle<TodoDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<ITodoTicketService, TodoTicketService>();
builder.Services.AddScoped<ITodoCategoryService, TodoCategoryService>();

builder.Services.AddScoped<ITodoStatusService, TodoStatusService>();
builder.Services.AddScoped<IVTodoTicketService, VTodoTicketService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
