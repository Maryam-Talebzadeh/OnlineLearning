using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineLearning.DataLayer.Context.EfCore;
using OnlineLearning.DataLayer.Repositories;
using OnlineLearning.DataLayer.Repositories.Interfaces;
using System.Reflection;
using OnlineLearning.Core.DTOs;
using OnlineLearning.DataLayer.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region DbContext

builder.Services.AddDbContext<OnlineLearningContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineLearningConnectionString"));
});

#endregion

#region IOC

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion

#region AutoMapping

//builder.Services.AddAutoMapper(typeof(Program).Assembly);

#endregion 

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
