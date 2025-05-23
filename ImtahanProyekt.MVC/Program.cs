using ImtahanProyekt.BL.Services;
using ImtahanProyekt.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ImtahanProyekt.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));
            builder.Services.AddScoped<TeamService>();
            builder.Services.AddScoped<AccountService>();
           // builder.Services.AddIdentity();

            var app = builder.Build();
            app.UseStaticFiles();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );
            app.MapControllerRoute(    
                name:"Default",
                pattern:"{Controller=Home}/{Action=Index}"            
                ); 

            app.Run();
        }
    }
}
