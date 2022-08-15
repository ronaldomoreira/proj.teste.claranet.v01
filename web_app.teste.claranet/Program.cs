using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace web_app.teste.claranet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string conn = builder.Configuration.GetConnectionString("DefaultConnection");
            if (conn.Contains("%DataDirectory%"))
            {
                conn = conn.Replace("%DataDirectory%", builder.Environment.ContentRootPath);
            }

            // Add services to the container.
            var connectionString = conn?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<IdentityAppDbContext>(options =>
                options.UseSqlServer((connectionString), b => b.MigrationsAssembly("web_app.teste.claranet")));
            builder.Services.AddDbContext<AppMainDbContext>(options =>
                options.UseSqlServer((connectionString), b => b.MigrationsAssembly("web_app.teste.claranet")));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<IdentityAppDbContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}