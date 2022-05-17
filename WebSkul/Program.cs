using Microsoft.EntityFrameworkCore;
using WebSkul.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SchoolContext>(   //Adiciona contexto de tipo SchoolContext
    options => options.UseInMemoryDatabase(databaseName:"testDB")   //Agrega base de datos en memoria
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//startup
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=School}/{action=Index}/{id?}");   //Controlador por defecto

app.Run();
