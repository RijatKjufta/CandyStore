using Candystore.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Candystore.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions options) : base(options) { }
        //*** have to tell the dataContext class about our models ***
        public DbSet<ApetisaniTypes> Apetisani { get; set; }
        public DbSet<CandyTypes> CandyTypes { get; set; }
        public DbSet<CoffeTypes> CoffeTypes { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // *************** DATA SEED:
            #region Admin and Roles
            const string ADMIN_ID = "b4280b6a-0613-4cbd-a9e6-f1701e926e73";
            const string ROLE_ID = ADMIN_ID;
            const string password = "Test123!";

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ROLE_ID,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                 new IdentityRole
                 {
                     Id = "b4280b6a-0613-4cbd-a9e6-f1701e926e74",
                     Name = "editor",
                     NormalizedName = "EDITOR"
                 },
                  new IdentityRole
                  {
                      Id = "b4280b6a-0613-4cbd-a9e6-f1701e926e75",
                      Name = "guest",
                      NormalizedName = "GUEST"
                  }
            );

            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "Test@test.com",
                NormalizedUserName = "Test@TEST.COM",
                Email = "Test@test.com",
                NormalizedEmail = "TEST@TEst.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, password),
                SecurityStamp = string.Empty,
                ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc58"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            #endregion

            #region Candy Data
            modelBuilder.Entity<CandyTypes>().HasData(
               new CandyTypes
               {
                   ID = 1,
                   CandyProduct = "Lolipop",
                   Description = "dasd",
                   price = 8.99

               },
               new CandyTypes
               {
                   ID = 2,
                   CandyProduct = "lizavce",
                   Description = "dkwopadk",
                   price = 6.99
               });
            #endregion

            #region Coffee Data
            modelBuilder.Entity<CoffeTypes>().HasData(
               new CoffeTypes
               {
                   ID = 1,
                   CoffeProduct = "Hausbraund",
                   Description = "gedafa",
                   Price = 15.99

               },
               new CoffeTypes
               {
                   ID = 2,
                   CoffeProduct = "Amigos",
                   Description = "jiodw",
                   Price = 11.99
               });
            #endregion

            #region Apetisani Data
            modelBuilder.Entity<ApetisaniTypes>().HasData(
               new ApetisaniTypes
               {
                   ID = 1,
                   ApetisaniProduct = "Semke",
                   Description = "dwkoap",
                   price = 4.99

               },
               new ApetisaniTypes
               {
                   ID = 2,
                   ApetisaniProduct = "Badem",
                   Description = "dkopwakf",
                   price = 7.99
               });
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
