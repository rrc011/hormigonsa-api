using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Talleres.EntityFrameworkCore
{
    public static class TalleresDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TalleresDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TalleresDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
