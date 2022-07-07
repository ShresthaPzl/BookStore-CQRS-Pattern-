using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Query
{
    public class QueryRepository : IQueryRepository
    {
        private readonly BookContext _context;
        public QueryRepository(BookContext context)
        {
            _context = context;
        }
        public async Task<List<BookEntity>> GetAllBook()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<BookEntity> GetBookById(int id) 
        {
            var book = await _context.Books.FindAsync(id);
            return book;
        }
    }
}
