using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CoffeShop.DAL;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EFCategoryRepository>();
builder.Services.AddScoped<IReservationService, ReservationManager>();
builder.Services.AddScoped<IReservationDal, EFReservationRepository>();
builder.Services.AddScoped<IMenuDal, EFMenuRepository>();
builder.Services.AddScoped<IMenuService, MenuManager>();
builder.Services.AddScoped<ISliderDal,EFSliderRepository>();
builder.Services.AddScoped<ISliderService,SliderManager>();
builder.Services.AddScoped<IServiceTableService,ServiceManager>();
builder.Services.AddScoped<IServiceDal,EFServiceRepository>();



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
           name: "areas",
           pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
         );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
