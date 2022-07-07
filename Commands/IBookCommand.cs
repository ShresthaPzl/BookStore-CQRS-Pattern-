using Models;
using System.Threading.Tasks;

namespace Commands
{
    public interface IBookCommand
    {
        Task<int> InsertBook(BookModel bookModel);
        Task<BookModel> UpdateBook(BookModel bookModel);
    }
}