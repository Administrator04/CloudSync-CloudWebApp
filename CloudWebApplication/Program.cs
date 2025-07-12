using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CloudWebApplication.Data;
using CloudWebApplication.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CloudWebApplicationContextConnection") ?? throw new InvalidOperationException("Connection string 'CloudWebApplicationContextConnection' not found.");

builder.Services.AddDbContext<CloudWebApplicationContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<CloudWebApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<CloudWebApplicationContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
