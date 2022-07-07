using Repository.Entities;
using System.Threading.Tasks;

namespace Domain.Command
{
    public interface ICommandRepository
    {
        Task<int> InsertBook(BookEntity bookEntity);
        Task<BookEntity> UpdateBook(BookEntity bookEntity);
    }
}