using KoiFishApp.Repositories.Entities;
using KoiFishApp.Repositories.Interface;
using KoiFishApp.Repositories.Repositories;
using KoiFishApp.Services.Interfaces;
using KoiFishApp.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình chuỗi kết nối cho DbContext
builder.Services.AddDbContext<QlcktnContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký các dịch vụ và repository
builder.Services.AddScoped<IPondServices, PondServices>();
builder.Services.AddScoped<IPondRepositories, PondRepositories>();
builder.Services.AddScoped<IWaterParameterRepositories, WaterParameterRepositores>();
builder.Services.AddScoped<IWaterParameterServices, WaterParameterServices>();
builder.Services.AddScoped<IKoiFishServices, KoiFishServices>();
builder.Services.AddScoped<IKoiFishRepositories, KoiFishRepositories>();
builder.Services.AddScoped<IKoiFishGrowthService, KoiFishGrowthService>();
builder.Services.AddScoped<IKoiFishGrowthRepository, KoiFishGrowthRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserRepositories, UserRepositories>();

// Thêm Razor Pages và các cấu hình khác
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
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
