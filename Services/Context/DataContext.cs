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
        public DbSet<UserModel> UserInfo {get; set;}
        public DbSet<ClubModel> ClubInfo {get; set;}
        public DbSet<PostModel> PostInfo {get; set;}
        public DbSet<FavoritedModel> FavoritesInfo {get; set;}
        public DbSet<CommentModel> CommentInfo {get; set;}

        // DbContextOptions options in the constructor allows you to configure the context when it's created, such as specifying the database provider, connection string, etc.
        public DataContext(DbContextOptions options): base(options){}

        // protected override void OnModelCreating(ModelBuilder modelBuilder) is a method where you can configure the database model, including entity relationships, table names, constraints, etc., using the provided ModelBuilder instance.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}