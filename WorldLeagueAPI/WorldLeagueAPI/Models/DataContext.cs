using Microsoft.EntityFrameworkCore;
using WorldLeagueAPI.Models;

namespace WorldLeagueAPI.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<TeamModel> Teams { get; set; }
        public DbSet<DrawResult> DrawResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamModel>().HasData(
                new TeamModel { Id = 1, Name = "Adesso İstanbul", Country = "Türkiye" },
                new TeamModel { Id = 2, Name = "Adesso Ankara", Country = "Türkiye" },
                new TeamModel { Id = 3, Name = "Adesso İzmir", Country = "Türkiye" },
                new TeamModel { Id = 4, Name = "Adesso Antalya", Country = "Türkiye" },
                new TeamModel { Id = 5, Name = "Adesso Berlin", Country = "Almanya" },
                new TeamModel { Id = 6, Name = "Adesso Frankfurt", Country = "Almanya" },
                new TeamModel { Id = 7, Name = "Adesso Münih", Country = "Almanya" },
                new TeamModel { Id = 8, Name = "Adesso Dortmund", Country = "Almanya" },
                new TeamModel { Id = 9, Name = "Adesso Paris", Country = "Fransa" },
                new TeamModel { Id = 10, Name = "Adesso Marsilya", Country = "Fransa" },
                new TeamModel { Id = 11, Name = "Adesso Nice", Country = "Fransa" },
                new TeamModel { Id = 12, Name = "Adesso Lyon", Country = "Fransa" },
                new TeamModel { Id = 13, Name = "Adesso Amsterdam", Country = "Hollanda" },
                new TeamModel { Id = 14, Name = "Adesso Rotterdam", Country = "Hollanda" },
                new TeamModel { Id = 15, Name = "Adesso Lahey", Country = "Hollanda" },
                new TeamModel { Id = 16, Name = "Adesso Eindhoven", Country = "Hollanda" },
                new TeamModel { Id = 17, Name = "Adesso Lisbon", Country = "Portekiz" },
                new TeamModel { Id = 18, Name = "Adesso Porto", Country = "Portekiz" },
                new TeamModel { Id = 19, Name = "Adesso Braga", Country = "Portekiz" },
                new TeamModel { Id = 20, Name = "Adesso Coimbra", Country = "Portekiz" },
                new TeamModel { Id = 21, Name = "Adesso Roma", Country = "İtalya" },
                new TeamModel { Id = 22, Name = "Adesso Milano", Country = "İtalya" },
                new TeamModel { Id = 23, Name = "Adesso Venedik", Country = "İtalya" },
                new TeamModel { Id = 24, Name = "Adesso Napoli", Country = "İtalya" },
                new TeamModel { Id = 25, Name = "Adesso Sevilla", Country = "İspanya" },
                new TeamModel { Id = 26, Name = "Adesso Madrid", Country = "İspanya" },
                new TeamModel { Id = 27, Name = "Adesso Barselona", Country = "İspanya" },
                new TeamModel { Id = 28, Name = "Adesso Granada", Country = "İspanya" },
                new TeamModel { Id = 29, Name = "Adesso Brüksel", Country = "Belçika" },
                new TeamModel { Id = 30, Name = "Adesso Brugge", Country = "Belçika" },
                new TeamModel { Id = 31, Name = "Adesso Gent", Country = "Belçika" },
                new TeamModel { Id = 32, Name = "Adesso Anvers", Country = "Belçika" }
            );
        }
    }
}
