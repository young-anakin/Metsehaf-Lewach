using LewachBookTrading.DTOs.LikeDTO;
using LewachBookTrading.Model;
using LewachBookTrading.Services.LikeService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace LewachBookTrading.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : Controller
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }


        [HttpPost("AddLike")]
        public async Task<ActionResult> AddLike(AddLikeDTO addLikeDTO)
        {
            try
            {
                var response = await _likeService.AddLike(addLikeDTO);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Error" });
            }
        }

        [HttpDelete("RemoveLike")]

        public async Task<ActionResult> RemoveLike(AddLikeDTO addLikeDTO)
        {
            try
            {
                var response = await _likeService.RemoveLike(addLikeDTO);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Error" });
            }
        }

        
    }
}
