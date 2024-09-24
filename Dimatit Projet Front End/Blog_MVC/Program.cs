using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
   // What kind of authentication you use? Here I just assume cookie authentication.
   .AddCookie(options =>
   {
       options.LoginPath = "/LogIn/LogIn";
   });
//builder.WebHost.UseWebRoot("wwwroot");
builder.Services.ConfigureApplicationCookie(options =>
{
    // If the LoginPath isn't set, ASP.NET Core defaults the path to /Account/Login.
    options.LoginPath = "/LogIn/LogIn"; // Set your login path here
});

var app = builder.Build();

IConfiguration configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//await Host.CreateDefaultBuilder(args)
//    .ConfigureWebHostDefaults(webBuilder =>
//    {
//        webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
//        webBuilder.UseWebRoot("wwwroot");
//    })
//    .Build()
//    .RunAsync();
//static IHostBuilder CreateHostBuilder(string[] args) =>
//         Host.CreateDefaultBuilder(args)
//             .ConfigureWebHostDefaults(webBuilder =>
//             {
//                 webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
//                 webBuilder.UseWebRoot("wwwroot");
//                 webBuilder.UseStartup<Startup>();
//             });

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseStatusCodePagesWithReExecute("/PageNotFound");
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LogIn}/{action=LogIn}");

app.Run();
