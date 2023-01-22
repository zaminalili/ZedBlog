using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZedBlog.Data.Context;
using ZedBlog.Data.Extensions;
using ZedBlog.Data.Repositories;
using ZedBlog.Entity.Entities;
using ZedBlog.Service.Extensions;
using ZedBlog.Service.Services.Abstract;
using ZedBlog.Service.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.LoadDataLayerExtension(builder.Configuration);
builder.Services.LoadServiceLayerExtension();
//builder.Services.AddSingleton<IBlogService, BlogService>();


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
