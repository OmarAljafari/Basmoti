using FinalProject.Models;
using FinalProject.Models.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(x =>x.EnableEndpointRouting=false);
builder.Services.AddIdentity<MyUserProject,IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddScoped<IRepository<MasterCategoryMenu>,MasterCategoryMenuRepository>();
builder.Services.AddScoped<IRepository<MasterContactUsInformation>,MasterContactUsInformationRepository>();
builder.Services.AddScoped<IRepository<TransactionBookTable>, TransactionBookTableRepository>();
builder.Services.AddScoped<IRepository<TransactionContactUs>,TransactionContactUsRepository>();
builder.Services.AddScoped<IRepository<TransactionNewsletter>,TransactionNewsletterRepository>();
builder.Services.AddScoped<IRepository<MasterItemMenu>,MasterItemMenuRepository>();
builder.Services.AddScoped<IRepository<MasterMenu>,MasterMenuRepository>();
builder.Services.AddScoped<IRepository<MasterWorkingHour>,MasterWorkingHourRepository>();
builder.Services.AddScoped<IRepository<MasterOffer>,MasterOfferRepository>();
builder.Services.AddScoped<IRepository<MasterPartner>, MasterPartnerRepository>();
builder.Services.AddScoped<IRepository<MasterService>, MasterServiceRepository>();
builder.Services.AddScoped<IRepository<MasterSocialMedia>, MasterSocialMediaRepository>();
builder.Services.AddScoped<IRepository<MasterSlider>, MasterSliderRepository>();
builder.Services.AddScoped<IRepository<SystemSetting>, SystemSettingRepositiry>();
builder.Services.AddScoped<IRepository<WhatPeopleSay>, WhatPeopleSayRepository>();




// 
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//})
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/admin/Account/Login";
//    });

//

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Admin/Account/Login";
});



builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});


var app = builder.Build();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    app.MapControllerRoute(
        name:"default1",
        pattern:"{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );
});

//app.MapGet("/", () => "Hello World!");

app.Run();
