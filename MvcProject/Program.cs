using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using Microsoft.EntityFrameworkCore;
using MvcProject.Controllers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICategoryDal, EFCategoryDal>();
builder.Services.AddScoped<IWriterDal, EFWriterDal>();
builder.Services.AddScoped<IHeadingDal, EFHeadingDal>();
builder.Services.AddScoped<IContentDal, EFContentDal>();
builder.Services.AddScoped<IAboutDal, EFAboutDal>();
builder.Services.AddScoped<IContactDal, EFContactDal>();
builder.Services.AddScoped<IMessageDal, EFMessageDal>();
builder.Services.AddScoped<IImageFileDal, EFImageFileDal>();
builder.Services.AddScoped<IAdminDal, EFAdminDal>();

builder.Services.AddScoped<IWriterService, WriterManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IHeadingService, HeadingManager>();
builder.Services.AddScoped<IContentService, ContentManager>();
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<IImageFileService, ImageFileManager>();
builder.Services.AddScoped<IAdminService, AdminManager>();
builder.Services.AddScoped<IWriterLoginService, WriterLoginManager>();


builder.Services.AddAuthentication("AdminCookie")
    .AddCookie("AdminCookie", options =>
    {
        options.LoginPath = "/Login/Index";
    });

builder.Services.AddAuthentication("UserCookie")
    .AddCookie("UserCookie", options =>
    {
        options.LoginPath = "/Login/WriterLogin";
    });

//builder.Services.AddScoped<CategoryManager>();
//builder.Services.AddScoped<WriterManager>();
//builder.Services.AddScoped<HeadingManager>();

//builder.Services.AddScoped<Context>(); 


builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Page{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
