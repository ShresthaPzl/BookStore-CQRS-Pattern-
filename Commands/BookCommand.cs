using Domain.Command;
using Models;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands
{
    public class BookCommand : IBookCommand
    {
        private readonly ICommandRepository _iCommandRepository;
        public BookCommand(ICommandRepository iCommandRepository)
        {
            _iCommandRepository = iCommandRepository;
        }

        public async Task<int> InsertBook(BookModel bookModel)
        {
            var bookEntity = new BookEntity()
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Author = bookModel.Author,
                Language = bookModel.Language,
                Genre = bookModel.Genre,
                CreatedOn = bookModel.CreatedOn
            };

            await _iCommandRepository.InsertBook(bookEntity);
            return bookEntity.Id;
        }

        public async Task<BookModel> UpdateBook(BookModel bookModel)
        {
            var bookEntity = new BookEntity()
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Author = bookModel.Author,
                Language = bookModel.Language,
                Genre = bookModel.Genre,
                CreatedOn = bookModel.CreatedOn
            };
            var updatedBookEntity = await _iCommandRepository.UpdateBook(bookEntity);
            var updatedBookModel = new BookModel()
            {
                Id = updatedBookEntity.Id,
                Title = updatedBookEntity.Title,
                Author = updatedBookEntity.Author,
                Language = updatedBookEntity.Language,
                Genre = updatedBookEntity.Genre,
                CreatedOn = updatedBookEntity.CreatedOn
            };
            return updatedBookModel;
        }
    }
}
