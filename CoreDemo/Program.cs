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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<IValidator<Writer>, WriterValidator>();
builder.Services.AddTransient<IValidator<Blog>, BlogValidator>();
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
builder.Services.AddScoped<INewsLetterService, NewsLetterManager>();
builder.Services.AddScoped<INewsLetterDal, EfNewsLetterDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<ILoginService, LoginManager>();
builder.Services.AddScoped<INotificationService, NotificationManager>();
builder.Services.AddScoped<INotificationDal, EfNotificationDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<IMessageDal, EfMessageDal>();

//builder.Services.AddSession();

//Proje seviyesinde Authorize Ýþlemleri
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                 .RequireAuthenticatedUser()
                 .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddMvc();

//Proje seviyesinde login return url oluþturuldu.
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme
    ).AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseStatusCodePages();
//Geçersiz url girilmesi dahilinde hata sayfasýna yönlendirmek için kullanýlýr
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code = {0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
//app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}");

app.Run();
