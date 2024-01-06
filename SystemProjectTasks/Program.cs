using Microsoft.EntityFrameworkCore;
using SystemProjectTasks.Models;
using SystemProjectTasks.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Inyección de dependencia de SystemProjectTasksContext
builder.Services.AddDbContext<SystemProjectTasksContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("SPTContext") ??
    throw new Exception("missing connection string")));

// Injección de dependecias de clases DAO
builder.Services.AddScoped<UserDAO>();
builder.Services.AddScoped<TaskDAO>();
builder.Services.AddScoped<ProjectDAO>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();