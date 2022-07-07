using Domain.Query;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    public class BookQuery : IBookQuery
    {
        private readonly IQueryRepository _iQueryRepository;

        public BookQuery(IQueryRepository iQueryRepository)
        {
            _iQueryRepository = iQueryRepository;
        }
        public async Task<List<BookModel>> GetAllBook()
        {
            var bookEntity = await _iQueryRepository.GetAllBook();
            var bookModel = bookEntity.Select(book => new BookModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Language = book.Language,
                Genre = book.Genre,
                CreatedOn = book.CreatedOn
            }).ToList();
            return bookModel;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var bookEntity = await _iQueryRepository.GetBookById(id);
            var bookModel = new BookModel()
            {
                Id = bookEntity.Id,
                Author = bookEntity.Author,
                Title = bookEntity.Title,
                Language = bookEntity.Language,
                Genre = bookEntity.Genre,
                CreatedOn = bookEntity.CreatedOn
            };

            return bookModel;
        }
    }
}
