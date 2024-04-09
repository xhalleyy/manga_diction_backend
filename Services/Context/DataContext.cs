using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using manga_diction_backend.Models;
using manga_diction_backend.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace manga_diction_backend.Services.Context
{
    public class DataContext : DbContext
    {
        public DbSet<UserModel> UserInfo { get; set; }
        public DbSet<ClubModel> ClubInfo { get; set; }
        public DbSet<PostModel> PostInfo { get; set; }
        public DbSet<FavoritedModel> FavoritesInfo { get; set; }
        public DbSet<CommentModel> CommentInfo { get; set; }
        public DbSet<FriendModel> FriendInfo { get; set; }
        public DbSet<MemberModel> MemberInfo { get; set; }

        // DbContextOptions options in the constructor allows you to configure the context when it's created, such as specifying the database provider, connection string, etc.
        public DataContext(DbContextOptions options) : base(options) { }

        // protected override void OnModelCreating(ModelBuilder modelBuilder) is a method where you can configure the database model, including entity relationships, table names, constraints, etc., using the provided ModelBuilder instance.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
        }


        // Seed / Initialize defaulted data in the database when database is created or migrated
        // private method that takes modelbuilder as its parameter; ModelBuilder is a class for building a model
        private void SeedData(ModelBuilder builder)
        {
            // intializes a list of UserModel objects, each representing a user with properties
            var defaultUsers = new List<UserModel>()
            {
                new UserModel()
                {
                    ID = 1,
                    Username = "halley",
                    FirstName = "halley",
                    LastName = "pham",
                    Age = 24,
                    ProfilePic = null,
                    Salt = "NFYMofXzkPjSPPBVSiV2o2YfemXRK5gXO5D6qpq3Q4omSN2QWRZ9okLKHFEI5x5/HehWFpVa3IB6Se2rTXFz5w==",
                    Hash = "PSFlappnv8ftPMmBorSedBnGjELhA2h5ikV9PAWCYYAa50jVrpoQXpHXJbftdCY6NwA7U0HxCtBhHFVnDFZxsyR8TTrd8oGEdBkruklbdptSNvowrpq2qpugljyJVOXbBafuSicn3GA62uRIUa5CSaEpjRd1gG+puZmTse/nYAyjCmFI5cOhuz1aaQe3/uHdtuKppuR3uJOcQrUlv1dVNzsBt1Y59YIVX3dzMx3BGSuGnnjJq6wTAFxl/Z20pD7xI3GmpvMZ3yjvA2MOTDaBifakzGZ8bnrkM3GPjXyO5juBiYsZqbXRLIYX/V+BHPXcjK6DCp9Hqaqpjz5Vs8WT4w=="
                },
                new UserModel()
                {
                    ID = 2,
                    Username = "sinatha",
                    FirstName = "sinatha",
                    LastName = "chin",
                    Age = 26,
                    ProfilePic = null,
                    Salt = "NxLWGIL6vGU220txp/GXGs144iMqXkQkRSuNX/ORZHGC/cxVcMEDNOuK+7w/3lxP6mAUFFXCD+cVdypK2TmY4g==",
                    Hash = "5W7eYQVwy46nN1Kbw1xD6Joia04j9fKQ34xmp/HXMl9ecr7LZKLdnbabRbhKjmivAGKS3MFgY+63+z3jwyCvmrpzGFLW2r/e2EAlA3KJQyiCksMQOqGHTqEyRmLTbERhR4OctvM3ayoIgrCPssbZY39Ul0sJ3/9L8YxWoQL8IWGGjk4elh0L44fLy66O6yAN5FTZ7yXVUYK78Zj1dDAc8t/UPL3WZQFGBQvKXjWg+bNUlDAOQ9cvSL7DaIE9iLUQyobabQXNvGR610ECuq6PhQB2exC+dgKp9NPYuDLBrZvQNAunjBARm0Uce4w60xiam3HVeZqsEhZBhkqgxEEMDQ=="
                },
                new UserModel()
                {
                    ID = 3,
                    Username = "avery",
                    FirstName = "avery",
                    LastName = "hillstrom",
                    Age = 22,
                    ProfilePic = null,
                    Salt = "2cwSsNNBcTbUB9ut3H4KOQLNCsXIgD79BHozo5sYBfi0PUJd4TozcI8UM+xkT3TDIxrP/SwJFzBSqKQbR2RZYA==",
                    Hash = "xBp/Z30KHEtPWYcgo7MrufRCSvgrtKBZ5xQqSTIn5ghTG5o+vj2bnrwalRpI3SbLIgT1XlGzRPOtjx4Aka7E8NPPtreqDLrcz0dc4OS4e4BGZ1SDhByokm0I3SOUJX3KKwbW3m4zGgkD6ctUGLqcrrmHnDsm3WN+tmGaW5xnFadlr+InxME4BdgVmB8jreLyMx60sFUXvNdmGKPC/jHA270YusRCGH2CljHKsL2moZWI/xDABUm7WaBKorrO2B22hkcH3tHNJcdkKjhHG5OzFTSj074wT7EaB5Spprqq2Cu7hRfZSfNe8Igc0ySAMojxk0jRYm+3nADHz2/GsFlwJQ=="
                },
            };
            builder.Entity<UserModel>().HasData(defaultUsers);
            // Configures intial data from defaultUsers by using Entity, which specifies the table we want to configure initial data
            // Has Data tells Entity Framework to include the provided data

            var defaultClubs = new List<ClubModel>()
            {
                new ClubModel()
                {
                    ID = 1,
                    LeaderId = 1,
                    ClubName = "Jujutsu Lovers<3",
                    Image = "https://p325k7wa.twic.pics/high/jujutsu-kaisen/jujutsu-kaisen-cursed-clash/00-page-setup/JJK-header-mobile2.jpg?twic=v1/resize=760/step=10/quality=80",
                    Description = "Gege Akutami hates his readers!",
                    DateCreated = "2024-04-05",
                    IsPublic = true,
                    IsDeleted = false
                },
                new ClubModel()
                {
                    ID = 2,
                    LeaderId = 1,
                    ClubName = "Villainess Arc",
                    Image = "https://static.animecorner.me/2022/09/villainess-manhwa-manga-novel-1024x576.png",
                    Description = "strong and evil FLs lol",
                    DateCreated = "2024-04-06",
                    IsPublic = true,
                    IsDeleted = false
                },
                
            };
            builder.Entity<ClubModel>().HasData(defaultClubs);

            var defaultPosts = new List<PostModel>(){
                new PostModel(){
                    ID = 1,
                    UserId = 1,
                    ClubId = 1,
                    Category = "Spoilers",
                    Tags = "Chapter 223,",
                    Description = "I can't believe that happened! And off-screened too... TT",
                    Image = null,
                    Likes = 3,
                    DateCreated = "2024-04-05",
                    DateUpdated = "2024-04-06",
                    IsDeleted = false
                },
                new PostModel(){
                    ID = 2,
                    UserId = 1,
                    ClubId = 1,
                    Category = "Discussion",
                    Tags = null,
                    Description = "Who is your guys' favorite character that is currently ALIVE!?",
                    Image = null,
                    Likes = 10,
                    DateCreated = "2024-04-06",
                    DateUpdated = "2024-04-07",
                    IsDeleted = false
                },
                new PostModel(){
                    ID = 3,
                    UserId = 2,
                    ClubId = 1,
                    Category = "Discussion",
                    Tags = null,
                    Description = "Why is Gege Akutami killing off EVERYBODY?????",
                    Image = null,
                    Likes = 3,
                    DateCreated = "2024-04-08",
                    DateUpdated = null,
                    IsDeleted = true
                }
            };
            builder.Entity<PostModel>().HasData(defaultPosts);
        }

    }
}