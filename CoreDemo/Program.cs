using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Add services to the container.
builder.Services.AddTransient<IValidator<Writer>, WriterValidator>();
builder.Services.AddControllersWithViews().AddFluentValidation(fv =>
{
    fv.DisableDataAnnotationsValidation = true;
});
builder.Services.AddScoped<DbContext, Context>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(EfGenericRepositoryBase<>));
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<IBlogService, BlogManager>();
builder.Services.AddScoped<IBlogDal, EfBlogDal>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ICommentDal, EfCommentDal>();
builder.Services.AddScoped<IWriterService, WriterManager>();
builder.Services.AddScoped<IWriterDal, EfWriterDal>();
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
