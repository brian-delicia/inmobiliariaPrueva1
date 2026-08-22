using Microsoft.EntityFrameworkCore;
using inmobiliariaPrueva1.Data;
using inmobiliariaPrueva1.Services;
using inmobiliariaPrueva1.DaoMySQL;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//coneccion a la DB
/*builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
)
);*/
builder.Services.AddScoped<PropietarioService>();
builder.Services.AddScoped<PropietarioDAO>(sp=>
{  
    var configuration=sp.GetRequiredService<IConfiguration>();

    var connectionString = configuration.GetConnectionString("DefaultConnection");
    
    return new PropietarioDAO(connectionString);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
