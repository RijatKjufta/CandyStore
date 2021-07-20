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
                   CandyProduct = "Bubble Bubble",
                   Description = "Sweat",
                   price = 5.99,
                   imgURL = "bubble-bubble.jpg"


               },
               new CandyTypes
               {
                   ID = 2,
                   CandyProduct = "Forrest Fruit Candies",
                   Description = "Sweat",
                   price = 5.99,
                   imgURL = "christmas-candycanes.jpg"

               },
               new CandyTypes
               {
                   ID = 3,
                   CandyProduct = "Fruit Sallad",
                   Description = "Sweat and Sour",
                   price = 5.99,
                   imgURL = "forrest-fruit-candy.jpg"

               },
               new CandyTypes
               {
                   ID = 4,
                   CandyProduct = "Forrest Fruit Candies",
                   Description = "Sweat",
                   price = 5.99,
                   imgURL = "fruit-salad-rock-candy.jpg"

               },
               new CandyTypes
               {
                   ID = 5,
                   CandyProduct = "Love Image Candies",
                   Description = "Sweat",
                   price = 5.99,
                   imgURL = "love-image-candy.jpg"

               },
               new CandyTypes
               {
                   ID = 6,
                   CandyProduct = "Mix Image Candies",
                   Description = "Sweat",
                   price = 5.99,
                   imgURL = "mix-hard-image-candy.jpg"

               },
               new CandyTypes
               {
                   ID = 7,
                   CandyProduct = "Ribbon Candies",
                   Description = "Sweat",
                   price = 5.99,
                   imgURL = "ribbon-candy.jpg"


               },
               new CandyTypes
               {
                   ID = 8,
                   CandyProduct = "Rock Candie",
                   Description = "Sweat",
                   price = 5.99,
                   imgURL = "rock-candy.png"

               },
               new CandyTypes
               {
                   ID = 9,
                   CandyProduct = "Christmas Candy",
                   Description = "Menthol and Sweet",
                   price = 5.99,
                   imgURL = "christmas-candycanes.jpg"
               });
            #endregion

            #region Coffee Data
            modelBuilder.Entity<CoffeTypes>().HasData(
               new CoffeTypes
               {
                   ID = 1,
                   CoffeProduct = "Hausbraund",
                   Description = "100% Arabica",
                   Price = 15.99,
                   imgURL = "hausbrandt-academia.jpg"

               },
               new CoffeTypes
               {
                   ID = 2,
                   CoffeProduct = "Amigos Blue",
                   Description = "100% Arabica",
                   Price = 15.99,
                   imgURL = "amigos-blue.jpeg"

               },
               new CoffeTypes
               {
                   ID = 3,
                   CoffeProduct = "Amigos Light",
                   Description = "100% Arabica",
                   Price = 15.99,
                   imgURL = "amigos-light.jpeg"
               },
               new CoffeTypes
               {
                   ID = 4,
                   CoffeProduct = "Auslesse",
                   Description = "100% Arabica",
                   Price = 15.99,
                   imgURL = "auslesse-caffe.png"

               },
               new CoffeTypes
               {
                   ID = 5,
                   CoffeProduct = "Boncampo",
                   Description = "100% Arabica",
                   Price = 15.99,
                   imgURL = "boncampo-clasic.jpg"

               },
               new CoffeTypes
               {
                   ID = 6,
                   CoffeProduct = "Chicco D'Oro",
                   Description = "100% Arabica",
                   Price = 15.99,
                   imgURL = "chicco-doro.png"

               },
               new CoffeTypes
               {
                   ID = 7,
                   CoffeProduct = "Doncaffe",
                   Description = "100% Arabica",
                   Price = 15.99,
                   imgURL = "doncaffe.jpg"

               },
               new CoffeTypes
               {
                   ID = 8,
                   CoffeProduct = "Frank",
                   Description = "100% Arabica",
                   Price = 19.99,
                   imgURL = "frank].png"

               },
               new CoffeTypes
               {
                   ID = 9,
                   CoffeProduct = "Housbrandt Academia",
                   Description = "100% Arabica",
                   Price = 20.99,
                   imgURL = "hausbrandt-academia.jpg"

               },
               new CoffeTypes
               {
                   ID = 10,
                   CoffeProduct = "Hausbraundt Black",
                   Description = "100% Arabica",
                   Price = 22.99,
                   imgURL = "hausbrandt-black.jpg"

               },
               new CoffeTypes
               {
                   ID = 11,
                   CoffeProduct = "Hausbraundt Espresso",
                   Description = "100% Arabica",
                   Price = 15.99,
                   imgURL = "hausbrandt-espresso.png"

               },
               new CoffeTypes
               {
                   ID = 12,
                   CoffeProduct = "Illy Mocca",
                   Description = "100% Arabica",
                   Price = 25.99,
                   imgURL = "illy mocca.jpg"

               },
               new CoffeTypes
               {
                   ID = 13,
                   CoffeProduct = "Amigos",
                   Description = "80% Arabica 20% Robusta",
                   Price = 11.99,
                   imgURL = "amigos-red.jpeg"
               });
            #endregion

            #region Apetisani Data
            modelBuilder.Entity<ApetisaniTypes>().HasData(
               new ApetisaniTypes
               {
                   ID = 1,
                   ApetisaniProduct = "Almonds",
                   Description = "Seeds for Joy",
                   price = 4.99,
                   imgURL = "almond-seeds.jpg"

               },
               new ApetisaniTypes
               {
                   ID = 2,
                   ApetisaniProduct = "Brazilian Nuts",
                   Description = "Seeds for Joy",
                   price = 10.99,
                   imgURL = "brazilian-nuts.jpg"

               },
               new ApetisaniTypes
               {
                   ID = 3,
                   ApetisaniProduct = "Chips Peanuts",
                   Description = "Seeds for Joy",
                   price = 4.99,
                    imgURL = "chips-peanuts.jpg"
               },
               new ApetisaniTypes
               {
                   ID = 4,
                   ApetisaniProduct = "Hazelnuts",
                   Description = "Seeds for Joy",
                   price = 9.99,
                   imgURL = "hazelnuts.jpg"

               },
               new ApetisaniTypes
               {
                   ID = 5,
                   ApetisaniProduct = "Indian Nuts",
                   Description = "Seeds for Joy",
                   price = 10.99,
                   imgURL = "indian-nuts.jpg"

               },
               new ApetisaniTypes
               {
                   ID = 6,
                   ApetisaniProduct = "Leblebi Sari",
                   Description = "Seeds for Joy",
                   price = 4.99,
                   imgURL = "leblebi-sari.jpg"

               },
               new ApetisaniTypes
               {
                   ID = 7,
                   ApetisaniProduct = "Peanuts",
                   Description = "Seeds for Joy",
                   price = 4.99,
                   imgURL = "peanuts.jpg"

               },
               new ApetisaniTypes
               {
                   ID = 8,
                   ApetisaniProduct = "Peanuts Covered",
                   Description = "Seeds for Joy",
                   price = 4.99,
                   imgURL = "peanuts-covered.jpg"

               },
               new ApetisaniTypes
               {
                   ID = 9,
                   ApetisaniProduct = "Pistachios",
                   Description = "Seeds for Joy",
                   price = 9.99,
                   imgURL = "pistaccio.jpg"

               },
               new ApetisaniTypes
               {
                   ID = 10,
                   ApetisaniProduct = "Popcorn",
                   Description = "Seeds for Joy",
                   price = 2.99,
                   imgURL = "popcorn4_4bee.jpg"

               },
               new ApetisaniTypes
               {
                   ID = 11,
                   ApetisaniProduct = "Pumpkin Seeds",
                   Description = "Seeds for Joy",
                   price = 3.99,
                   imgURL = "pumpkin-seeds.jpg"

               },
               new ApetisaniTypes
               {
                   ID = 12,
                   ApetisaniProduct = "Red Pistachios",
                   Description = "Seeds for Joy",
                   price = 12.99,
                   imgURL = "red-pistacios.jpg "

               },
               new ApetisaniTypes
               {
                   ID = 13,
                   ApetisaniProduct = "Sunflower Seeds",
                   Description = "Seeds for Joy",
                   price = 3.99,
                   imgURL = "sunflower-seeds.jpg "

               },
               new ApetisaniTypes
               {
                   ID = 14,
                   ApetisaniProduct = "Sweet Corn",
                   Description = "Seeds for Joy",
                   price = 4.99,
                   imgURL = "sweet-corn.jpg"

               },
               new ApetisaniTypes
               {
                   ID = 15,
                   ApetisaniProduct = "Sweet Peanuts",
                   Description = "Seeds for Joy",
                   price = 5.99,
                   imgURL = "sweet-peanuts.jpg"

               },
               new ApetisaniTypes
               {
                   ID = 16,
                   ApetisaniProduct = "Wallnuts",
                   Description = "Seeds for Joy",
                   price = 8.99,
                   imgURL = "wallnuts.jpg"

               });

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
