using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Helpers;
using Services;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DB
builder.Services.AddDbContext<PersonnelManagementContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//mapper
builder.Services.AddAutoMapper(typeof(AppMappingProfile));

//repo
builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IRepository<Department>, DepartmentRepository>();
builder.Services.AddScoped<IRepository<PersonnelMovements>, PersonnelMovementsRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//service
builder.Services.AddScoped<ICRUD<Employee>, EmployeeService>();
builder.Services.AddScoped<ICRUD<Department>, DepartmentService>();
builder.Services.AddScoped<ICRUD<PersonnelMovements>, PersonnelMovementsService>();
builder.Services.AddScoped<IReport, ReportService>();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Department}/{action=All}/{id?}");

app.Run();
