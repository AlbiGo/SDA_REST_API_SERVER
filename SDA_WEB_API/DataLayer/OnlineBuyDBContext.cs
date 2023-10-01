using Microsoft.EntityFrameworkCore;
using SDA_WEB_API.DataLayer.Models;

namespace SDA_WEB_API.DataLayer
{
    public class OnlineBuyDBContext : DbContext
    {
        public OnlineBuyDBContext(DbContextOptions<OnlineBuyDBContext> options)
            : base(options) { }

        public DbSet<Artikull> Artikujt { get; set; }
        public DbSet<Fatura> Faturat { get; set; }
        public DbSet<FaturaDaljes> FaturaDaljes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserToken> UsersToken { get; set; }
    }
}
