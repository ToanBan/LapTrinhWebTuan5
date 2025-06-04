namespace WebBanStore.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product>Products { get; set; }
        public DbSet<ProductImage>ProductImages { get; set; }
    }
}
