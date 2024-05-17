﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using manga_diction_backend.Services.Context;

#nullable disable

namespace fullstackbackend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240516164702_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("manga_diction_backend.Models.ClubModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ClubName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<int?>("LeaderId")
                        .HasColumnType("int");

                    b.Property<bool>("isMature")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("ClubInfo");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ClubName = "Jujutsu Lovers<3",
                            DateCreated = "2024-04-05",
                            Description = "Gege Akutami hates his readers!",
                            Image = "https://p325k7wa.twic.pics/high/jujutsu-kaisen/jujutsu-kaisen-cursed-clash/00-page-setup/JJK-header-mobile2.jpg?twic=v1/resize=760/step=10/quality=80",
                            IsDeleted = false,
                            IsPublic = true,
                            LeaderId = 1,
                            isMature = false
                        },
                        new
                        {
                            ID = 2,
                            ClubName = "Villainess Arc",
                            DateCreated = "2024-04-06",
                            Description = "strong and evil FLs lol",
                            Image = "https://static.animecorner.me/2022/09/villainess-manhwa-manga-novel-1024x576.png",
                            IsDeleted = false,
                            IsPublic = true,
                            LeaderId = 1,
                            isMature = false
                        },
                        new
                        {
                            ID = 3,
                            ClubName = "Psychological Manhwas",
                            DateCreated = "2024-04-10",
                            Description = "scared but i cant stop reading...",
                            Image = "https://static1.srcdn.com/wordpress/wp-content/uploads/2023/10/best-horror-manhwa-featured-image.jpg",
                            IsDeleted = false,
                            IsPublic = true,
                            LeaderId = 3,
                            isMature = true
                        },
                        new
                        {
                            ID = 4,
                            ClubName = "Best Webtoons",
                            DateCreated = "2024-04-11",
                            Description = "Talk about Webtoons!",
                            Image = "https://academychronicle.com/wp-content/uploads/2021/03/Webtoons-900x472.jpg",
                            IsDeleted = false,
                            IsPublic = true,
                            LeaderId = 3,
                            isMature = false
                        },
                        new
                        {
                            ID = 5,
                            ClubName = "Solo Leveling!",
                            DateCreated = "2024-04-11",
                            Description = "Rave about Solo Leveling!!!",
                            Image = "https://static1.srcdn.com/wordpress/wp-content/uploads/2023/12/solo-leveling.jpg",
                            IsDeleted = false,
                            IsPublic = true,
                            LeaderId = 3,
                            isMature = false
                        },
                        new
                        {
                            ID = 6,
                            ClubName = "Shoujo 4ever ",
                            DateCreated = "2024-04-09",
                            Description = "Shoujo debatably has the best mangas!",
                            Image = "https://static1.cbrimages.com/wordpress/wp-content/uploads/2022/09/shoujo-male-leads.jpg",
                            IsDeleted = false,
                            IsPublic = true,
                            LeaderId = 2,
                            isMature = false
                        });
                });

            modelBuilder.Entity("manga_diction_backend.Models.CommentModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("ParentCommentId")
                        .HasColumnType("int");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reply")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("CommentInfo");
                });

            modelBuilder.Entity("manga_diction_backend.Models.FavoritedModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<string>("MangaId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("FavoritedInfo");
                });

            modelBuilder.Entity("manga_diction_backend.Models.FriendModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("FriendId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("FriendInfo");
                });

            modelBuilder.Entity("manga_diction_backend.Models.LikesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LikedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LikesInfo");
                });

            modelBuilder.Entity("manga_diction_backend.Models.MemberModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MemberInfo");
                });

            modelBuilder.Entity("manga_diction_backend.Models.NotificationModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("ClubId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("NotificationInfo");
                });

            modelBuilder.Entity("manga_diction_backend.Models.PostModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("DateCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateUpdated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("PostInfo");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Category = "Spoilers",
                            ClubId = 1,
                            DateCreated = "2024-04-05",
                            DateUpdated = "2024-04-06",
                            Description = "I can't believe that happened! And off-screened too... TT",
                            IsDeleted = false,
                            Tags = "CH.223,",
                            Title = "What happed to Gojo can't be real, right!?",
                            UserId = 1
                        },
                        new
                        {
                            ID = 2,
                            Category = "Discussion",
                            ClubId = 1,
                            DateCreated = "2024-04-06",
                            DateUpdated = "2024-04-07",
                            IsDeleted = false,
                            Title = "Who is your guys' favorite character that is currently ALIVE!?",
                            UserId = 1
                        },
                        new
                        {
                            ID = 3,
                            Category = "Discussion",
                            ClubId = 1,
                            DateCreated = "2024-04-08",
                            Description = "Why is Gege Akutami killing off EVERYBODY?????",
                            IsDeleted = true,
                            Title = "I got some words to say to Gege...",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("manga_diction_backend.Models.UserModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UserInfo");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Age = 24,
                            FirstName = "halley",
                            Hash = "PSFlappnv8ftPMmBorSedBnGjELhA2h5ikV9PAWCYYAa50jVrpoQXpHXJbftdCY6NwA7U0HxCtBhHFVnDFZxsyR8TTrd8oGEdBkruklbdptSNvowrpq2qpugljyJVOXbBafuSicn3GA62uRIUa5CSaEpjRd1gG+puZmTse/nYAyjCmFI5cOhuz1aaQe3/uHdtuKppuR3uJOcQrUlv1dVNzsBt1Y59YIVX3dzMx3BGSuGnnjJq6wTAFxl/Z20pD7xI3GmpvMZ3yjvA2MOTDaBifakzGZ8bnrkM3GPjXyO5juBiYsZqbXRLIYX/V+BHPXcjK6DCp9Hqaqpjz5Vs8WT4w==",
                            LastName = "pham",
                            Salt = "NFYMofXzkPjSPPBVSiV2o2YfemXRK5gXO5D6qpq3Q4omSN2QWRZ9okLKHFEI5x5/HehWFpVa3IB6Se2rTXFz5w==",
                            Username = "halley"
                        },
                        new
                        {
                            ID = 2,
                            Age = 26,
                            FirstName = "sinatha",
                            Hash = "5W7eYQVwy46nN1Kbw1xD6Joia04j9fKQ34xmp/HXMl9ecr7LZKLdnbabRbhKjmivAGKS3MFgY+63+z3jwyCvmrpzGFLW2r/e2EAlA3KJQyiCksMQOqGHTqEyRmLTbERhR4OctvM3ayoIgrCPssbZY39Ul0sJ3/9L8YxWoQL8IWGGjk4elh0L44fLy66O6yAN5FTZ7yXVUYK78Zj1dDAc8t/UPL3WZQFGBQvKXjWg+bNUlDAOQ9cvSL7DaIE9iLUQyobabQXNvGR610ECuq6PhQB2exC+dgKp9NPYuDLBrZvQNAunjBARm0Uce4w60xiam3HVeZqsEhZBhkqgxEEMDQ==",
                            LastName = "chin",
                            Salt = "NxLWGIL6vGU220txp/GXGs144iMqXkQkRSuNX/ORZHGC/cxVcMEDNOuK+7w/3lxP6mAUFFXCD+cVdypK2TmY4g==",
                            Username = "sinatha"
                        },
                        new
                        {
                            ID = 3,
                            Age = 22,
                            FirstName = "avery",
                            Hash = "xBp/Z30KHEtPWYcgo7MrufRCSvgrtKBZ5xQqSTIn5ghTG5o+vj2bnrwalRpI3SbLIgT1XlGzRPOtjx4Aka7E8NPPtreqDLrcz0dc4OS4e4BGZ1SDhByokm0I3SOUJX3KKwbW3m4zGgkD6ctUGLqcrrmHnDsm3WN+tmGaW5xnFadlr+InxME4BdgVmB8jreLyMx60sFUXvNdmGKPC/jHA270YusRCGH2CljHKsL2moZWI/xDABUm7WaBKorrO2B22hkcH3tHNJcdkKjhHG5OzFTSj074wT7EaB5Spprqq2Cu7hRfZSfNe8Igc0ySAMojxk0jRYm+3nADHz2/GsFlwJQ==",
                            LastName = "hillstrom",
                            Salt = "2cwSsNNBcTbUB9ut3H4KOQLNCsXIgD79BHozo5sYBfi0PUJd4TozcI8UM+xkT3TDIxrP/SwJFzBSqKQbR2RZYA==",
                            Username = "avery"
                        });
                });

            modelBuilder.Entity("manga_diction_backend.Models.CommentModel", b =>
                {
                    b.HasOne("manga_diction_backend.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("manga_diction_backend.Models.LikesModel", b =>
                {
                    b.HasOne("manga_diction_backend.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}