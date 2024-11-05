using LewachBookTrading.DTOs.BookDTO;
using LewachBookTrading.Model;
using LewachBookTrading.Services.BookService;
using Microsoft.AspNetCore.Mvc;

namespace LewachBookTrading.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("AddBook")]

        public async Task<ActionResult> AddBook([FromBody] AddBookDTO addBookDTO)
        {
            try
            {
                var response = await _bookService.AddBook(addBookDTO);

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Internal Server Error" });
            }
            
        }

        [HttpGet("GetAllBooks")]
        public async Task<ActionResult> GetAllBooks()
        {
            try
            {
                var response = await _bookService.GetAllBooks();

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Internal Server Error" });
            }

            

        }

        [HttpGet("GetBookById")]
        public async Task<ActionResult> GetBookById(int Id)
        {
            try
            {
                var response = await _bookService.GetBookById(Id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Internal Server Error" });
            }
            
        }

        [HttpPut("UpdateBook")]
        public async Task<ActionResult> UpdateBook(UpdateBookDTO updateBookDTO)
        {
            try
            {
                var response = await _bookService.UpdateBook(updateBookDTO);
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Internal Server Error" });
            }

        }

        [HttpDelete("DeleteBook")]
        public async Task<ActionResult> DeleteBook(int Id)
        {
            try
            {
                var response = await _bookService.DeleteBook(Id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Internal Server Error" });
            }

        }

    }
}
