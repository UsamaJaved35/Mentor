using Mentor.Models;
using Mentor.Models.Interfaces;
using Mentor.Models.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tutor_Finder.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Getting Connection string
string connString = builder.Configuration.GetConnectionString("Mentor");
//Getting Assembly Name
var migrationAssembly = typeof(Program).Assembly.GetName().Name;

// Add services to the container.
builder.Services.AddSingleton<IStudent, StudentRepository>();
builder.Services.AddSingleton<ILogin, LoginRepository>();
builder.Services.AddSingleton<ITutor, TutorRepository>();
//builder.Services.AddDbContext<StudentContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:EmployeeDB"]));
builder.Services.AddDbContext<StudentContext>(options =>
{
    //the change occurs here.
    //builder.cofiguration and not just configuration
    options.UseSqlServer(builder.Configuration.GetConnectionString("Mentor"));
});
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
