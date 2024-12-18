using CarSharing.Application.Common.Interfaces;
using CarSharing.Application.Services.Implementation;
using CarSharing.Application.Services.Interface;
using CarSharing.Infrastructure.Data;
using CarSharing.Infrastructure.identity;
using CarSharing.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string conString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<CarSharingDBContext>(x => x.UseSqlServer(conString));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
// .AddEntityFrameworkStores<CarSharingDBContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IBorrowingService, BorrowingService>();
builder.Services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<CarSharingDBContext>();

//Autorisatie
builder.Services.AddAuthorization(options => {
    options.AddPolicy("AdminOnly", policyBuilder => policyBuilder.RequireClaim("IsAdmin"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.MapRazorPages();

app.Run();
