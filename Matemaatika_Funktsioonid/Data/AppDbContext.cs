using Matemaatika_Funktsioonid.Models;
using Microsoft.EntityFrameworkCore;   // ← ЭТОГО НЕ ХВАТАЕТ!

namespace Matemaatika_Funktsioonid.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<FunktsiooniUurimine> FunktsiooniUurimised { get; set; }
    }
}