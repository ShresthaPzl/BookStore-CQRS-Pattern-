using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Query
{
    public interface IQueryRepository
    {
        Task<List<BookEntity>> GetAllBook();
        Task<BookEntity> GetBookById(int id);
    }
}