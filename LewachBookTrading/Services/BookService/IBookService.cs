using LewachBookTrading.DTOs.BookDTO;
using LewachBookTrading.Model;

namespace LewachBookTrading.Services.BookService
{
    public interface IBookService
    {
        Task<Book> AddBook(AddBookDTO addBookDTO);
        Task<Book> DeleteBook(int id);
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int Id);
        Task<Book> UpdateBook(UpdateBookDTO updateBookDTO);
    }
}
