
using Microsoft.EntityFrameworkCore;
using SaleWebMvc.Data;
using SaleWebMvc.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Adicionar o contexto do Entity Framework Core
builder.Services.AddDbContext<BancoContexts>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Toda vez que o meu IContatoRepository for usado,
// uma instância do ContatoRepository será chamado.
builder.Services.AddScoped< IContatoRepository, ContatoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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
