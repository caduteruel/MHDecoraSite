using MHDecora.Admin.Application;
using MHDecora.Admin.Application.Interfaces;
using MHDecora.Admin.Application.Services;
using MHDecora.Admin.Domain.Interfaces;
using MHDecora.Admin.Infra;
using MHDecora.Admin.Infra.Repositories;
using MHDecora.Admin.Infra.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do contexto do banco de dados Oracle
builder.Services.AddDbContext<AdminContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Configuração de Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<AdminContext>();

// Configuração de políticas de autorização
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

// Configuração de cookies para autenticação
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Home/Error"; // Rota para a página de acesso negado
    // Aqui você pode configurar outros aspectos dos cookies, se necessário
});

// Injeção de dependências para serviços e repositórios
builder.Services.AddScoped<IBannerService, BannerService>();
builder.Services.AddScoped<IQuemSomosService, QuemSomosService>();
builder.Services.AddScoped<IMontagemService, MonstagemService>();
builder.Services.AddScoped<ITemaService, TemaService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IContatoService, ContatoService>();

builder.Services.AddScoped<IBannerRepository, BannerRepository>();
builder.Services.AddScoped<IQuemSomosRepository, QuemSomosRepository>();
builder.Services.AddScoped<IMontagemRepository, MontagemRepository>();
builder.Services.AddScoped<ITemaRepository, TemaRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();

// Configuração para acessar IConfiguration em todo o aplicativo
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Middleware para lidar com exceções não tratadas
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); // Adicione isso para usar autenticação

app.UseAuthorization();

// Rota padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

