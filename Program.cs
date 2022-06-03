 using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebProject.Areas.Identity.Data;
using WebProject.Blogging;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("UserDBContextConnection") ?? throw new InvalidOperationException("Connection string 'UserDBContextConnection' not found.");
var connectionString1 = builder.Configuration.GetConnectionString("BlogContextConnection") ?? throw new InvalidOperationException("Connection string 'UserDBContextConnection' not found.");

builder.Services.AddDbContext<BlogDBContext>(options =>
    options.UseSqlServer(connectionString1));;

builder.Services.AddDbContext<UserDBContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<WPUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<UserDBContext>();;


// Add services to the container.
builder.Services.AddControllersWithViews();
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
app.MapRazorPages();


app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
