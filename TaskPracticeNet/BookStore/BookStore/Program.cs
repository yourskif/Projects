using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;

var builder = WebApplication.CreateBuilder(args);

// ������ �������� ���������� � ������� ������������
builder.Services.AddControllersWithViews();

// ������������� InMemoryDatabase ������ ������� SQL ����
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("TestDb"));  // "TestDb" - ��'� ��� ���� � ���'��

var app = builder.Build();

// ������������� ������� ����� (CSS, JS, ���������� � �.�.)
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// ����������� ������� ��� ����������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authors}/{action=Create}/{id?}");

app.Run();





//using Microsoft.EntityFrameworkCore;
//using BookStore.Data;
//using BookStore.Models;


//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//var app = builder.Build();

//    app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Authors}/{action=Create}/{id?}");

//app.Run();


