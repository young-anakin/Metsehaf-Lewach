using LewachBookTrading.DTOs.BookDTO;
using LewachBookTrading.DTOs.PostDTO;
using LewachBookTrading.Model;
using LewachBookTrading.Services.PostService;
using Microsoft.AspNetCore.Mvc;

namespace LewachBookTrading.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService) { 
            _postService = postService;
        }

        [HttpPost("AddPost")]

        public async Task<ActionResult> AddPost(AddPostDTO addPostDTO)
        {
            try
            {
                var response = await _postService.AddPost(addPostDTO);

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Internal Server Error" });
            }

        }

        [HttpGet("GetAllPosts")]

        public async Task<ActionResult> GetAllPosts()
        {
            try
            {
                var response = await _postService.GetAllPosts();
                return Ok(response);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Internal Server Error" });
            }

        }

        [HttpGet("GetPostById")]

        public async Task<ActionResult> GetPostById(int id)
        {
            try
            {
                var response = await _postService.GetPostById(id);
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Internal Server Error" });
            }

        }

        [HttpPut("UpdatePost")]

        public async Task<ActionResult> UpdatePost(UpdatePostDTO updatePostDTO)
        {
            try {
                var response = await _postService.UpdatePost(updatePostDTO);
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Can't Update Post" });
            }
        }

        [HttpDelete("DeletePost")]

        public async Task<ActionResult> DeletePost(int Id)
        {
            try
            {
                var response = await _postService.DeletePost(Id);
                return Ok(response);
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Can't Delete Post" });
            }
        }

        [HttpGet("GetPostOfSpecificUser")]

        public async Task<ActionResult> GetPostOfSpecificUser(int Id)
        {
            try
            {
                var response = await _postService.GetPostOfSpecificUser(Id);
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "No Such User" });
            }
        }

    }
}
