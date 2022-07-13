using DesafioFinalAcademiaAtos.Models;
using DesafioFinalAcademiaAtos.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//STRING DE CONEXÃO
builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer("Server=DESKTOP-VBMT0I5;Database=DesafioFinalAcademiaAtos;Trusted_Connection=True;"));


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
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
