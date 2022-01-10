using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Database.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Monster> Monsters { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var monsters = new List<Monster>
            {
                new()
                {
                    Id = 1,
                    Name = "Titan of dawn",
                    HitPoints = 80,
                    Damage = 4,
                    AttackPerRound = 1,
                    AttackModifer = 8,
                    DamageModifer = 3,
                    Weapon = 0,
                    ArmorClass = 16
                },
                new()
                {
                    Id = 2,
                    Name = "Elk",
                    HitPoints = 13,
                    Damage = 1,
                    AttackPerRound = 1,
                    AttackModifer = 2,
                    DamageModifer = 1,
                    Weapon = 1,
                    ArmorClass = 10
                },
                new()
                {
                    Id = 3,
                    Name = "Orthon",
                    HitPoints = 105,
                    Damage = 3,
                    AttackPerRound = 3,
                    AttackModifer = 10,
                    DamageModifer = 2,
                    Weapon = 3,
                    ArmorClass = 17
                }
            };
            modelBuilder.Entity<Monster>().HasData(monsters);
            base.OnModelCreating(modelBuilder);
        }
    }
}