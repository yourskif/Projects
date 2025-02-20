using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UnivercityDepartment.Models;
using UnivercityDepartment.Services;  // ������� ��

var builder = WebApplication.CreateBuilder(args);

// ������ DbContext ��� UnivercityContext � ������������� SQL Server
builder.Services.AddDbContext<UnivercityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityDb")));

// ������ ������ ��� ������ � ������������, ������������ �� ����������
builder.Services.AddScoped<UniversityService>();  // ��� �������� ����� ��� �����������
builder.Services.AddScoped<FacultyService>();     // ����� ��� ����������
builder.Services.AddScoped<IFacultyService, FacultyService>(); // ��������� ��� FacultyService

// ������ ����� ��� ��������
builder.Services.AddScoped<StudentService>();     // ����� ��� ��������

// ������ ���������� � ���������
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ���� �� � ����� ��������, ������ ������� �������
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();  // �������� ������� ��������� ������� ����� (CSS, JS, ���������� ����)
app.UseRouting();
app.UseAuthorization();

// ��������� �������� ��� ����������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  // ��������� �� �������������

// ��������� �������� ��� ������������
app.MapControllerRoute(
    name: "departments",
    pattern: "Departments/{action=Index}/{id?}"); // ������� ��� ������������

// ��������� �������� ��� ����������
app.MapControllerRoute(
    name: "faculties",
    pattern: "Faculties/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "teachers",
    pattern: "Teachers/{action=Index}/{id?}");



app.Run();



