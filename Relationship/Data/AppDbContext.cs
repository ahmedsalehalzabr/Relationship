using Microsoft.EntityFrameworkCore;

namespace Relationship.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImage> BlogsImages { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Tag> Tags { get; set; }
        
    }


  
   // One To One
    public class Blog
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public BlogImage BlogImage { get; set; }
    }

    public class BlogImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Caption { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    // One To Many 

    public class Book
    {
        public int BookId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

    }

    // Many To Many

    public class Car
    {
        public int CarId { get; set; }
        public string Title { get; set; }

        public ICollection<Tag> Tags { get; set;}
    }

    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; } 

        public ICollection<Car> Cars { get; set; }
    }


}
