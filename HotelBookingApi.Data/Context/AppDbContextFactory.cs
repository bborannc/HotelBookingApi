using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HotelBookingApi.Data.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // 1. API projesindeki appsettings.json dosyasının fiziksel yolunu belirliyoruz
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../HotelBookingApi.API");

            // 2. ConfigurationBuilder ile appsettings.json dosyasını okuyoruz
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 3. appsettings.json içindeki ConnectionStrings:DefaultConnection değerini alıyoruz
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // 4. DbContext seçeneklerini dinamik gelen connection string ile yapılandırıyoruz
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}