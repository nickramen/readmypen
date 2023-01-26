using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using readmypen.DataAccess.Interfaces;
using readmypen.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using readmypen.DataAccess;


var builder = WebApplication.CreateBuilder(args);

// Added services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUsersRepository, UsersRepository>();

var app = builder.Build();

var config = app.Configuration.GetValue<string>("ConnectionStrings:readmypenConnectionString");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accounts}/{action=Login}/{id?}");

app.Run();

