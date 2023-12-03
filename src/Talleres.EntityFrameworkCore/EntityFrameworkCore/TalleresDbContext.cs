using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Talleres.Authorization.Roles;
using Talleres.Authorization.Users;
using Talleres.MultiTenancy;

namespace Talleres.EntityFrameworkCore
{
    public class TalleresDbContext : AbpZeroDbContext<Tenant, Role, User, TalleresDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentCycle> EquipmentCycles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public TalleresDbContext(DbContextOptions<TalleresDbContext> options)
            : base(options)
        {
        }
    }
}
