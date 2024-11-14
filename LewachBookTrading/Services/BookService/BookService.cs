using LewachBookTrading.Context;
using LewachBookTrading.DTOs.BookDTO;
using LewachBookTrading.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LewachBookTrading.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly DataContext _context;
        //private readonly IWebHostEnvironment _webHostEnvironment;
        public BookService(DataContext context)
        {
            _context = context;
            //_webHostEnvironment = webHostEnvironment;
        }

        public async Task<Book> AddBook(AddBookDTO addBookDTO)
        {
            var book = new Book();
            //book.Trades = addBookDTO.Trades;
            book.Title = addBookDTO.Title;
            book.Description = addBookDTO.Description;
            //book.Experiences = addBookDTO.Experiences;
            //book.Owner = addBookDTO.Owner;
            book.OwnerId = addBookDTO.OwnerId;
            book.Genre = addBookDTO.Genre;

            //if (addBookDTO.CoverPage != null) {
            //    string folder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            //    if (!Directory.Exists(folder))
            //    {
            //        Directory.CreateDirectory(folder);
            //    }
            //    string uniqueFileName = Guid.NewGuid().ToString() + "_" + addBookDTO.CoverPage.FileName;
            //    string filePath = Path.Combine(folder, uniqueFileName);

            //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await addBookDTO.CoverPage.CopyToAsync(fileStream);
                //}
                
                //addBookDTO.CoverPagePath = "/uploads/" + uniqueFileName;
                //book.CoverPagePath = addBookDTO.CoverPagePath;
                //book.CoverPage = addBookDTO.CoverPage;
            //}

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;

        }
        public async Task<Book> GetBookById(int Id)
        {
            var book = await _context.Books.Where(b => b.Id == Id).FirstOrDefaultAsync();
            if (book == null)
            {
                throw new Exception("Book not found");

            }
            return book;
        }

        public async Task<Book> UpdateBook(UpdateBookDTO updateBookDTO)
        {
            var book = await _context.Books.Where(b => b.Id == updateBookDTO.Id).FirstOrDefaultAsync();
            if (book == null)
            {
                throw new Exception("Book not found");
            }
            book.Title = updateBookDTO.Title;
            book.Description = updateBookDTO.Description;
            book.Genre = updateBookDTO.Genre;
            book.OwnerId = updateBookDTO.OwnerId;

            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return book;
            
        }
        public async Task<Book> DeleteBook(int id)
        {
            var book = await _context.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return book;
            }
            throw new Exception("Book not found");


        }
    }
}