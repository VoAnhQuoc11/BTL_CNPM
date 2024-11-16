using KoiFishApp.Repositories;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Repositories.Intrefaces;
using KoiFishApp.Sevices;
using KoiFishApp.Sevices.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<QlcktnContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KoiFishApp")));

// ??ng ký các repository và service
builder.Services.AddScoped<IUserRepositories, UserRepositories>();
builder.Services.AddScoped<IUserServices, UserServices>();


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Login"; // ???ng d?n ??n trang ??ng nh?p
            options.LogoutPath = "/Logout";
            options.AccessDeniedPath = "/AccessDenied";
        });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});


app.Run();