using MHDecora.Site.Application;
using MHDecora.Site.Application.Interfaces;
using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using MHDecora.Site.Infra;
using MHDecora.Site.Infra.Repositories;
using MHDecora.Site.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("OracleConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<AdminContext>(options =>
//    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<SiteContext>(options =>
            options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuração da injeção de dependência
builder.Services.AddScoped<IBannerService, BannerService>();
builder.Services.AddScoped<IQuemSomosService, QuemSomosService>();
builder.Services.AddScoped<IMontagemService, MontagemService>();
builder.Services.AddScoped<ITemaService, TemaService>();

// Registrar o serviço do repositório e a implementação
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IBannerRepository, BannerRepository>();
builder.Services.AddScoped<IQuemSomosRepository, QuemSomosRepository>();
builder.Services.AddScoped<IMontagemRepository, MontagemRepository>();
builder.Services.AddScoped<ITemaRepository, TemaRepository>();


var adminRootPath = Path.Combine(builder.Environment.ContentRootPath, "..", "MHDecora.Admin", "wwwroot", "images");

builder.Services.AddSingleton(new PathOptions { AdminRootPath = adminRootPath });


var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(adminRootPath),
    RequestPath = "/images"
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

