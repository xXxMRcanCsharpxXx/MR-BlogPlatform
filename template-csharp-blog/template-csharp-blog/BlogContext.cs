using Microsoft.EntityFrameworkCore;
using template_csharp_blog.Models;

namespace template_csharp_blog
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=BlogDB_Summer2022;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
            new Category() { Id = 1, Name = "Movies" },
            new Category() { Id = 2, Name = "Shoes"},
            new Category() { Id = 3, Name = "Music"}
            );

             modelBuilder.Entity<Post>().HasData(
               new Post() { Id = 1, Title = "Nike Example", Body = "Nike review", Author = "John Doe", CategoryId = 2},
               new Post() { Id = 2, Title = "Jordan Example", Body = "Jordan review", Author = "Jane Doe", CategoryId = 2},
               new Post() { Id = 3, Title = "Texas Chainsaw Massacre Example", Body = "Texas Chainsaw Massacre review", Author = "John Doe", CategoryId = 1 },
               new Post() { Id = 4, Title = "Hiphop/Rap Example", Body = "Hiphop/Rap review", Author = "Jane Doe", CategoryId = 3},
               new Post() { Id = 5, Title = "Metal Example", Body = "Metal review", Author = "John Doe", CategoryId = 3 }
               );
        }


    }
}
