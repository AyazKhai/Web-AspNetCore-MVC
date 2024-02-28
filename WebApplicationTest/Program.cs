using Microsoft.EntityFrameworkCore;
using WebApplicationTest.Models;

var builder = WebApplication.CreateBuilder(args);

// получаем строку подключения из файла конфигурацииВ данном случае мы будем использовать упрощенный движок базы данных LocalDB,
// который представляет легковесную версию SQL Server Express, предназначенную специально для разработки приложений.
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Emploee}/{action=GetEmployees}/{id?}");

app.Run();
