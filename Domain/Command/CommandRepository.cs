using Repository;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command
{
    public class CommandRepository : ICommandRepository
    {
        private readonly BookContext _context;
        public CommandRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<int> InsertBook(BookEntity bookEntity)
        {
            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();
            return bookEntity.Id;
        }

        public async Task<BookEntity> UpdateBook(BookEntity bookEntity)
        {
             _context.Books.Update(bookEntity);
             await _context.SaveChangesAsync();

            return bookEntity;
        }
    }
}
