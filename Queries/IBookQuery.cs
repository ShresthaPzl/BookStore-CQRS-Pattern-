using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Queries
{
    public interface IBookQuery
    {
        Task<List<BookModel>> GetAllBook();
        Task<BookModel> GetBookById(int id);
    }
}