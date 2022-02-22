using Entities.Entities;

namespace BookFrontEnd.Interfaces
{
    public interface IBookService
    {
        Task<IList<Book>> GetAllBooks();
        Task<IList<Book>> GetAllBooksByTitle(string title);
    }
}
