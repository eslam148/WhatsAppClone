
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using ChatDB;
using Microsoft.AspNetCore.Identity;

namespace WhatsAppClone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            builder.Services.AddDbContext<ChatDB.AppContext>(options =>
            {
                options
                    .UseSqlServer(builder.Configuration.GetConnectionString("DBKey"));
            });

            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ChatDB.AppContext>().AddDefaultTokenProviders();

            builder.Services.AddControllersWithViews();
            builder.Services.AddSignalR();
            var app = builder.Build();
            app.UseStaticFiles(new StaticFileOptions()
            {
                RequestPath = "/wwwroot",
                FileProvider = new PhysicalFileProvider
            (Path.Combine(Directory.GetCurrentDirectory(),
            "wwwroot"))
            });
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

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapHub<Chathubs>("/chatHub");
            app.Run();
        }
    }
}