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

using (var scope = app.Services.CreateScope())  //using indica que libere memoria cuando termine su ultima instruccion
{
    var services = scope.ServiceProvider;   //ServiceProvider devuelve todos los servicios, extrae el servicio necesario, en este caso el dbcontext SchoolContext

    try
    {
        var context = services.GetRequiredService<SchoolContext>();   //Obtiene el servicio dbcontext de SchoolContext
        context.Database.EnsureCreated();   //Se asegura que todo esta creado, ppr lo que va SchoolContext e invoca el metodo OnModelCreating
    }
    catch (Exception e)
    {

        var logger = services.GetRequiredService<ILogger<Program>>();   //Servicio para guardar en un log
        logger.LogError(e, "A ocurrido un error en la creacion de la Base de datos");
    }
}


app.Run();
