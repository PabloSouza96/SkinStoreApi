using Microsoft.EntityFrameworkCore;
using SkinStoreApi.Models;

namespace SkinStoreApi.Data
{
    public class SkinStoreApiContext : DbContext
    {
        public SkinStoreApiContext(DbContextOptions<SkinStoreApiContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Skin> Skin { get; set; }
        public DbSet<UserSkin> UserSkin { get; set; }
    }
}
