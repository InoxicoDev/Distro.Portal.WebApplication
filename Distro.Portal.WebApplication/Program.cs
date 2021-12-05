using Distro.Admin.BusinessServices.Services;
using Distro.Admin.Contracts.Entities;
using Distro.Admin.Contracts.Services;
using Distro.Admin.DataAccess.Repositories;
using Distro.Ordering.DataAccess.Repositories;
using Distro.Ordering.Domain.Contracts;
using Distro.Ordering.Domain.Entities;
using Distro.Ordering.Domain.Services.Services;
using Distro.Portal.WebApplication.Proxies;
using Distro.Seedworks.Domain.Services;
using Distro.Seedworks.Infrastructure.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// TODO: Find a way to specify different DbContext for different repositories injections

//builder.Services.AddScoped<IRepository<User>, UserRepository>();
//builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
//builder.Services.AddScoped<IRepository<Order>, OrderRepository>();

//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<ICustomerService, CustomerService>();
//builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddScoped<IOrderHistoryService, OrderHistoryService>();


builder.Services.AddScoped<IUserService, UserProxy>();
builder.Services.AddScoped<ICustomerService, CustomerProxy>();
builder.Services.AddScoped<IOrderService, OrderProxy>();
builder.Services.AddScoped<IOrderHistoryService, OrderHistoryProxy>();


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
