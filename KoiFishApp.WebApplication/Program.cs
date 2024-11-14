using KoiFishApp.Repositories.Entities;
using KoiFishApp.Repositories.Interface;
using KoiFishApp.Repositories.Repositories;
using KoiFishApp.Services.Interfaces;
using KoiFishApp.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Đăng ký DbContext
builder.Services.AddDbContext<QlcktnContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký repository và service
builder.Services.AddScoped<IPondRepositories, PondRepositories>();  // Đăng ký IPondRepositories với PondRepositories
builder.Services.AddScoped<IPondServices, PondServices>();  // Đăng ký IPondServices với PondServices

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
