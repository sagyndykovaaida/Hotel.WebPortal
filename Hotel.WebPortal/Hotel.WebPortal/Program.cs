using Hotel.WebPortal.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Configuration;
using Hotel.WebPortal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc(options =>
{
    //options.Filters.Add<EEFilter>();

}
    
    ).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);


builder.Services.Configure<RequestLocalizationOptions>(options =>
{

    builder.Services.Configure<APIEnpoint>(builder.Configuration.GetSection("APIEnpoint"));
    var supportedCulture = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("kk-KZ"),
        new CultureInfo("ru-RU")
    };
    options.SupportedCultures = supportedCulture;
    options.SupportedUICultures = supportedCulture;
});
 
//connect to database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HotelAtrContext>(options => options.UseSqlServer(connectionString));



builder.Services.AddLocalization(option => option.ResourcesPath = "Resources");
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(3600); // Изменено с 5 секунд на 1 час для увеличения времени сессии
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Home/Login";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
