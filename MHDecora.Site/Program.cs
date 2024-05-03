using MHDecora.Site.Application;
using MHDecora.Site.Application.Interfaces;
using MHDecora.Site.Domain.Interfaces;
using MHDecora.Site.Infra;
using MHDecora.Site.Infra.Repositories;
using MHDecora.Site.Infra.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Obtenha a string de conex�o do arquivo de configura��o diretamente
var connectionString = builder.Configuration["ConnectionStrings:MHDConnection"];

// Configura��o do DbContext para PostgreSQL
builder.Services.AddDbContext<SiteContext>(options => options.UseNpgsql(connectionString));

// Add services to the container.
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
