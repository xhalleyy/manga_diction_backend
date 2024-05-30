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
        public DbSet<LikesModel> LikesInfo { get; set;}
        public DbSet<FavoritedModel> FavoritedInfo { get; set; }
        public DbSet<CommentModel> CommentInfo { get; set; }
        public DbSet<FriendModel> FriendInfo { get; set; }
        public DbSet<MemberModel> MemberInfo { get; set; }
        public DbSet<NotificationModel> NotificationInfo { get; set; }

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
                    Salt = "/30Q+tbEfHNYV+VcY1x7a31f4XmOVA2yzroBOtjmH7wrp7YmdfL0NDEuVHgGi4P4IkpsVuG9EWJd2urVNqmbzw==",
                    Hash = "MYGwrD+IpxAU3sAsMzYkB824c72f6q3qqZ6DVeLn+XNhilTuCwCyPD2L8bOd/m3Mwa4dW/PVPGXhgN86wpYlEeWTfC3GFKLY4qgY5URSxQ6Sp+5N0I+Z+wNu9OmUj8gM3RDH27Cx6EP37+EAD9vZ34LWuXfDcMSB8oERSTGTnzel2yzbiOE4Mfd03ExP+7Njp2dKtemAT7y7U0Rj+A0UfcVsma1IPhdZTCK4eXu8CTp052IwKR3ngP8VGFnjMgV8I9RMFb2wlihz1o7jXWwVJql3Js1sCUNguVd/yftd+iyCMRjmbzM5qKaSyEVO0bOj8LGyPXSG81xsSzlq7KtLYw=="
                },
                new UserModel()
                {
                    ID = 2,
                    Username = "sinatha",
                    FirstName = "sinatha",
                    LastName = "chin",
                    Age = 26,
                    ProfilePic = null,
                    Salt = "CRAotl001YDT/5efujzfPNZgRgsHrMX245qm4UdYEAywoKS7Q/50TjGqtagexEvicAMG6aesvktSh9Ockjo2KA==",
                    Hash = "fT+cOf3xNyRCVGcPJEQxJPHail6WHIOuIiWZeMIfxoI/nogga3T/c5/ICdXTaWvksz8IztKx3sdZaMp0NvWuNRs9F40ThehO5eJjzvjvwaOa0JAY041iNykhv7iAF4WTTzouXjIogKrB3ytMsSQKcsQw+nVk5w0HMp485HF0Vgio+5kK107RafTXW84VJ0/9lh+mFoWRk/N+owXbVC6QIKo0E/9N3Au97IY7lDbKdHgkzyOt+QK/KTmKLevK85ZD2rqeJ5+CPrgOUHJHbhgmaqepxRec0Z0v6vKossEvh64pMAl+VDKCibUHCCQSTIIvv3/ZBNOJEYCkH7o0CpdisA=="
                },
                new UserModel()
                {
                    ID = 3,
                    Username = "avery",
                    FirstName = "avery",
                    LastName = "hillstrom",
                    Age = 22,
                    ProfilePic = null,
                    Salt = "vYsW/2t4uzl5B4xJif8NR1jsDjOOg81fuRALEWnr5ZDRxSJGHe0P0j2940TX0sEbm/IRu48o4DByngNVhhmRjQ==",
                    Hash = "NiYV4qFQHnsPgQCkcQLNujA0y1lOP7ak0PEqkhjUdpvDMQGWVcntx0QBPpuW8QFF0wOz4ugE8qacLUHCMsfYcCEqTd1Trhg29/LzcnIXHsIcyx+MVH+0UXTL4X8KFUSQ1dfdnVdlWx3/BoVrX6ue1Nm1AW00wFkr/Uku+IAzphr/yl2J6eXf9ZUdOODS2YOumOWrrl1PYWs+se9PrzGsZUnnNXYdnw8DlxuM+kkPUx+M2w0du++B9B6y/hsI32l3GBsj7QSA89DS+962hk0MOlinQgv3KO+892xD0hGeTSg/1M2/IS5s7J8yaoFbh0VJsanrke8pEua55VFzFgeodQ=="
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
                    DateCreated = "2024-04-05 09:10:11",
                    isMature = false,
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
                    DateCreated = "2024-04-06 09:10:11",
                    isMature = false,
                    IsPublic = true,
                    IsDeleted = false
                },
                new ClubModel(){
                    ID = 3,
                    LeaderId = 3,
                    ClubName = "Psychological Manhwas",
                    Image = "https://static1.srcdn.com/wordpress/wp-content/uploads/2023/10/best-horror-manhwa-featured-image.jpg",
                    Description = "scared but i cant stop reading...",
                    DateCreated = "2024-04-10 09:10:11",
                    isMature = true,
                    IsPublic = true,
                    IsDeleted = false
                },
                new ClubModel(){
                    ID = 4,
                    LeaderId = 3,
                    ClubName = "Best Webtoons",
                    Image = "https://academychronicle.com/wp-content/uploads/2021/03/Webtoons-900x472.jpg",
                    Description = "Talk about Webtoons!",
                    DateCreated = "2024-04-11 09:10:11",
                    isMature = false,
                    IsPublic = true,
                    IsDeleted = false
                },
                new ClubModel(){
                    ID = 5,
                    LeaderId = 3,
                    ClubName = "Solo Leveling!",
                    Image = "https://static1.srcdn.com/wordpress/wp-content/uploads/2023/12/solo-leveling.jpg",
                    Description = "Rave about Solo Leveling!!!",
                    DateCreated = "2024-04-11 08:10:11",
                    isMature = false,
                    IsPublic = true,
                    IsDeleted = false
                },
                new ClubModel(){
                    ID = 6,
                    LeaderId = 2,
                    ClubName = "Shoujo 4ever ",
                    Image = "https://static1.cbrimages.com/wordpress/wp-content/uploads/2022/09/shoujo-male-leads.jpg",
                    Description = "Shoujo debatably has the best mangas!",
                    DateCreated = "2024-04-09 10:10:11",
                    isMature = false,
                    IsPublic = true,
                    IsDeleted = false
                }
                
            };
            builder.Entity<ClubModel>().HasData(defaultClubs);

            var defaultPosts = new List<PostModel>(){
                new PostModel(){
                    ID = 1,
                    UserId = 1,
                    ClubId = 1,
                    Category = "Spoilers",
                    Tags = "CH.223",
                    Title ="What happed to Gojo can't be real, right!?",
                    Description = "I can't believe that happened! And off-screened too... TT",
                    Image = null,
                    // Likes = 3,
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
                    Title="Who is your guys' favorite character that is currently ALIVE!?",
                    Description = null,
                    Image = null,
                    // Likes = 10,
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
                    Title = "I got some words to say to Gege...",
                    Description = "Why is Gege Akutami killing off EVERYBODY?????",
                    Image = null,
                    // Likes = 3,
                    DateCreated = "2024-04-08",
                    DateUpdated = null,
                    IsDeleted = true
                }
            };
            builder.Entity<PostModel>().HasData(defaultPosts);
        }

    }
}