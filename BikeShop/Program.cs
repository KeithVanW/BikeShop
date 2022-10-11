using BikeShop.Database;
using BikeShop.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BikeDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddTransient<IBikeDatabase, BikeDatabase>();
builder.Services.AddTransient<IBikeService, BikeService>();

builder.Services.AddTransient<ICustomerDatabase, CustomerDatabase>();
builder.Services.AddTransient<ICustomerService, CustomerService>();

builder.Services.AddTransient<IItemDatabase, ItemDatabase>();
builder.Services.AddTransient<IItemService, ItemService>();

builder.Services.AddTransient<IBagDatabase, BagDatabase>();
builder.Services.AddTransient<IBagService, BagService>();

builder.Services.AddAutoMapper(typeof(Program));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();