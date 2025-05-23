using HospitalManagement.BusinessLayer.HospitalManagementBAL.MastersBAL;
using HospitalManagement.Data;
using HospitalManagement.Infrastructure.Contracts;
using HospitalManagement.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(configuration.GetConnectionString("Conn")));
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(configuration.GetConnectionString("Conn")),
//    ServiceLifetime. // Ensure Scoped Lifetime
//);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var constr = builder.Configuration.GetConnectionString("Conn");
    options.UseSqlServer(constr);
});

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUnitOfWorkHMS, UnitOfWorkHMS>();
builder.Services.AddScoped<MstHospitalRegistrationBAL>();
builder.Services.AddScoped<IMstHospitalRegistrationRepository, MstHospitalRegistrationRepository>();

builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.ViewLocationFormats.Clear();
    options.ViewLocationFormats.Add("/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
    options.ViewLocationFormats.Add("/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
    options.ViewLocationFormats.Add("/Views/MstHospitalRegistration/HospitalRegistration/{0}" + RazorViewEngine.ViewExtension);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
