using LewachBookTrading.Context;
using LewachBookTrading.DTOs.CommentDTO;
using LewachBookTrading.Model;
using LewachBookTrading.Services.CommentService;
using Microsoft.AspNetCore.Mvc;

namespace LewachBookTrading.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("AddComment")]
        public async Task<ActionResult> AddComment(AddCommentDTO addCommentDTO)
        {
            try 
            { 
                var response = await _commentService.AddComment(addCommentDTO);
                return Ok(response);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Can't Add Comment" });
            }
        }

        [HttpDelete("DeleteComment")]

        public async Task<ActionResult> DeleteComment(int Id)
        {
            try
            {

                var response = await _commentService.DeleteComment(Id);
                return Ok(response);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "No Such Comment" });
            }

        }
    }
}
