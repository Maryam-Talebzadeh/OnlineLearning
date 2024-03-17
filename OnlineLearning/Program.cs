using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineLearning.DataLayer.Context.EfCore;
using OnlineLearning.DataLayer.Repositories;
using OnlineLearning.DataLayer.Repositories.Interfaces;
using System.Reflection;
using OnlineLearning.Core.DTOs;
using OnlineLearning.DataLayer.UnitOfWork;
using OnlineLearning.Core.Services.Interfaces;
using OnlineLearning.Core.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using OnlineLearning.Core.Convertors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
//builder.Services
//    .AddRazorPages()
//    .AddRazorPagesOptions(options =>
//    {
//        options.Conventions.AddPageRoute("/index", "{*url}");
//    });

#region DbContext

builder.Services.AddDbContext<OnlineLearningContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineLearningConnectionString"));
});

#endregion

#region IOC

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<IViewRenderService, RenderViewToString>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddTransient<IWalletService, WalletService>();
builder.Services.AddTransient<IAdminService, AdminService>();
builder.Services.AddTransient<IPermissionService, PermissionService>();

#endregion

#region AutoMapping

//builder.Services.AddAutoMapper(typeof(Program).Assembly);

#endregion 

#region Authentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/Login";
    options.LogoutPath = "/Logout";
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
}
);

#endregion

var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");



app.Run();
