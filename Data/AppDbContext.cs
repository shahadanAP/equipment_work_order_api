using Microsoft.EntityFrameworkCore;
using EquipmentApi.Models;

namespace EquipmentApi.Data{

    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<CrewMembers> CrewMembers { get; set; }
        public DbSet<WorkOrders> WorkOrders { get; set; }
    }
}