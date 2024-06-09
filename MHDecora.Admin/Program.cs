using MHDecora.Admin.Application;
using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Application.Services;
using MHDecora.Admin.Data;
using MHDecora.Admin.Domain.Interfaces;
using MHDecora.Admin.Infra;
using MHDecora.Admin.Infra.CrossCutting;
using MHDecora.Admin.Infra.Repositories;
using MHDecora.Admin.Infra.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("OracleConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<AdminContext>(options =>
//    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<AdminContext>(options =>
            options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AdminContext>();
builder.Services.AddControllersWithViews();

// Services
builder.Services.AddScoped<IBannerService, BannerService>();
builder.Services.AddScoped<IQuemSomosService, QuemSomosService>();
builder.Services.AddScoped<IMontagemService, MonstagemService>();
builder.Services.AddScoped<ITemaService, TemaService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IContatoService, ContatoService>();
//builder.Services.AddScoped<IOrcamentoService, OrcamentoService>();


// Repositories
builder.Services.AddScoped<IBannerRepository, BannerRepository>();
builder.Services.AddScoped<IQuemSomosRepository, QuemSomosRepository>();
builder.Services.AddScoped<IMontagemRepository, MontagemRepository>();
builder.Services.AddScoped<ITemaRepository, TemaRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
//builder.Services.AddScoped<IOrcamentoRepository, OrcamentoRepository>();

builder.Services.AddScoped<ILogger, Logger<AdminContext>>();

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

app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(@"C:\FW\projetos\MH Decora\site-novo", "Imagens")),
    RequestPath = "/Imagens"
});

// Rota espec�fica para o Site
app.MapControllerRoute(
    name: "site",
    pattern: "site/{controller=Home}/{action=Index}/{id?}");

// Rota espec�fica para Admin, se necess�rio
app.MapControllerRoute(
    name: "admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}");

// Rota padr�o
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
