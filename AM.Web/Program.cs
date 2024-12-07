using AM.Applicationcore.Interfaces;
using AM.Applicationcore.Services;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Injection des dependence 
builder.Services.AddDbContext<DbContext,AMContext>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddSingleton<Type>(t => typeof(GenericRepository<>));

//Injection des services
builder.Services.AddScoped<IServicePlane, ServicePlane>();
builder.Services.AddScoped<IServiceFlight, ServicveFlight>();

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
