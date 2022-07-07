using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Repository.Entities;

namespace Repository
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            :base(options)
        {
        }
        [Display(Name = "Book")]
        public DbSet<BookEntity> Books { get; set; }
    }
}
