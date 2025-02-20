using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UnivercityDepartment.Models;
using UnivercityDepartment.Services;  // Додайте це

var builder = WebApplication.CreateBuilder(args);

// Додаємо DbContext для UnivercityContext з використанням SQL Server
builder.Services.AddDbContext<UnivercityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityDb")));

// Додаємо сервіси для роботи з університетом, факультетами та студентами
builder.Services.AddScoped<UniversityService>();  // Ваш основний сервіс для університету
builder.Services.AddScoped<FacultyService>();     // Сервіс для факультетів
builder.Services.AddScoped<IFacultyService, FacultyService>(); // Інтерфейс для FacultyService

// Додаємо сервіс для студентів
builder.Services.AddScoped<StudentService>();     // Сервіс для студентів

// Додаємо контролери з поданнями
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Якщо не в режимі розробки, додаємо обробку помилок
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();  // Дозволяє серверу обробляти статичні файли (CSS, JS, зображення тощо)
app.UseRouting();
app.UseAuthorization();

// Створення маршруту для контролерів
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  // Контролер за замовчуванням

// Створення маршруту для департаментів
app.MapControllerRoute(
    name: "departments",
    pattern: "Departments/{action=Index}/{id?}"); // Маршрут для департаментів

// Створення маршруту для факультетів
app.MapControllerRoute(
    name: "faculties",
    pattern: "Faculties/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "teachers",
    pattern: "Teachers/{action=Index}/{id?}");



app.Run();



