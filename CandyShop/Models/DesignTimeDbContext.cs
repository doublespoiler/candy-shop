using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CandyShop.Models
{
  public class CandyShopContextFactory : IDesignTimeDbContextFactory<CandyShopContext>
  {

    CandyShopContext IDesignTimeDbContextFactory<CandyShopContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<CandyShopContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new CandyShopContext(builder.Options);
    }
  }
}