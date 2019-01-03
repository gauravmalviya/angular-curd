using System.Collections.Generic;
using System.Threading.Tasks;
using bookapi.ViewModels;

namespace bookapi.ServiceContracts
{
    public interface IBookService
    {
        Task<List<BookViewModel>> GetBooks();
        Task<BookViewModel> GetBook(string id);
        Task<string> SaveBook(BookViewModel inputData);
        Task<string> UpdateBook(string id, BookViewModel inputData);
        Task<int?> DeleteBook(string id);
    }
}