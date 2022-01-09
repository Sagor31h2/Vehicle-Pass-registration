using Microsoft.EntityFrameworkCore;
using VehiclePassRegister.Models;

namespace VehiclePassRegister.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
