using MHDecora.Admin.Data;
using MHDecora.Admin.Infra;
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

// Adiciona configura��o para carregar o appsettings.json do MHDecora.Admin
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var env = hostingContext.HostingEnvironment;
    config.SetBasePath(Directory.GetCurrentDirectory());
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
          .AddJsonFile(Path.Combine("..", "MHDecora.Admin", "appsettings.json"), optional: true, reloadOnChange: true)
          .AddEnvironmentVariables();

    if (args != null)
    {
        config.AddCommandLine(args);
    }
});

// Acessa a configura��o
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("OracleConnection") ?? throw new InvalidOperationException("Connection string 'OracleConnection' not found.");

// Configura os contextos e servi�os
builder.Services.AddDbContext<SiteContext>(options =>
            options.UseOracle(connectionString));

// Adiciona o contexto AdminContext se necess�rio
builder.Services.AddDbContext<AdminContext>(options =>
            options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Adiciona servi�os ao cont�iner
builder.Services.AddControllersWithViews();

// Configura��o da inje��o de depend�ncia
builder.Services.AddScoped<IBannerService, BannerService>();
builder.Services.AddScoped<IQuemSomosService, QuemSomosService>();
builder.Services.AddScoped<IMontagemService, MontagemService>();
builder.Services.AddScoped<ITemaService, TemaService>();

// Registrar o servi�o do reposit�rio e a implementa��o
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IBannerRepository, BannerRepository>();
builder.Services.AddScoped<IQuemSomosRepository, QuemSomosRepository>();
builder.Services.AddScoped<IMontagemRepository, MontagemRepository>();
builder.Services.AddScoped<ITemaRepository, TemaRepository>();

// Configura o caminho para o conte�do est�tico do MHDecora.Admin
var adminRootPath = Path.Combine(builder.Environment.ContentRootPath, "..", "MHDecora.Admin", "wwwroot");
builder.Services.AddSingleton(new PathOptions { AdminRootPath = adminRootPath });

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Configura o uso de arquivos est�ticos para servir o conte�do do MHDecora.Admin
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(adminRootPath),
    RequestPath = string.Empty // Serve diretamente do root
});

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
