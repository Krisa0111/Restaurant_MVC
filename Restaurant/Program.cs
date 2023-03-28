using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Helpers;

namespace Restaurant
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddOutputCaching();
            builder.Services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            builder.Services.AddTransient<TableBuilder>();
            builder.Services.AddDbContext<RestaurantDbContext>(opt =>
            {
                opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Restaurant;Trusted_Connection=True;MultipleActiveResultSets=true");
            });

            var app = builder.Build();
            app.UseOutputCaching();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}