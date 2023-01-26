using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using readmypen.DataAccess;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Added services to the container.
builder.Services.AddControllersWithViews();

// Add by nickramen
var connectionString = builder.Configuration.GetConnectionString("readmypenConnectionString");
builder.Services.AddDbContext<DbContext>(x => x.UseSqlServer(connectionString));


var app = builder.Build();

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
