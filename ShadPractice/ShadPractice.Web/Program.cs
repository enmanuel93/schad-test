using Microsoft.EntityFrameworkCore;
using ShadPractice.Core.Contexts;
using ShadPractice.Web.Helpers;
using System.Configuration;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ApplicationName = typeof(Program).Assembly.FullName,
    ContentRootPath = Directory.GetCurrentDirectory(),
    EnvironmentName = Environments.Staging,
    WebRootPath = "wwwroot"
});

//sql connection
builder.Services.AddDbContext<TestInvoiceContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("TestInvoiceContext"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    }));

//This extension method inject all services
builder.Services.AddServices();

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

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
    pattern: "{controller=Invoice}/{action=Print}/{id?}");
    //pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
