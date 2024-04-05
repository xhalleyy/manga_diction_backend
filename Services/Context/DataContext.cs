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


        private void SeedData(ModelBuilder builder)
        {
            var defaultUsers = new List<UserModel>()
            {
                new UserModel()
                {
                    ID = 1,
                    Username = "halley",
                    FirstName = "halley",
                    LastName = "pham",
                    Age = 24,
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
                    Salt = "2cwSsNNBcTbUB9ut3H4KOQLNCsXIgD79BHozo5sYBfi0PUJd4TozcI8UM+xkT3TDIxrP/SwJFzBSqKQbR2RZYA==",
                    Hash = "xBp/Z30KHEtPWYcgo7MrufRCSvgrtKBZ5xQqSTIn5ghTG5o+vj2bnrwalRpI3SbLIgT1XlGzRPOtjx4Aka7E8NPPtreqDLrcz0dc4OS4e4BGZ1SDhByokm0I3SOUJX3KKwbW3m4zGgkD6ctUGLqcrrmHnDsm3WN+tmGaW5xnFadlr+InxME4BdgVmB8jreLyMx60sFUXvNdmGKPC/jHA270YusRCGH2CljHKsL2moZWI/xDABUm7WaBKorrO2B22hkcH3tHNJcdkKjhHG5OzFTSj074wT7EaB5Spprqq2Cu7hRfZSfNe8Igc0ySAMojxk0jRYm+3nADHz2/GsFlwJQ=="
                },
            };
            builder.Entity<UserModel>().HasData(defaultUsers);
        }

    }
}