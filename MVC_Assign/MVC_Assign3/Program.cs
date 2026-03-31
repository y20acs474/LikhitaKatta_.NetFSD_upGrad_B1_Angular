namespace MVC_Assign3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // ✅ ADD THIS (Session Service)
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // ✅ ADD THIS (Enable Session Middleware)
            app.UseSession();

            app.UseAuthorization();

            app.MapStaticAssets();

            // ✅ CHANGE DEFAULT ROUTE (IMPORTANT)
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Login}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}