using LewachBookTrading.DTOs.UserDTO;
using LewachBookTrading.Model;
using LewachBookTrading.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace LewachBookTrading.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        //Add a new Employee 
        [HttpPost("AddUser")]
        public async Task<ActionResult> AddEmployee(AddUserDTO userDTO)
        {
            try
            {

                return Ok(await _userService.AddUser(userDTO));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ErrorResponse { Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ErrorResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Internal Server Error" });
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult> UpdateUser(UpdateUserDTO userDTO)
        {
            try
            {

                return Ok(await _userService.UpdateUser(userDTO));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ErrorResponse { Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ErrorResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Internal Server Error" });
            }
        }
        [HttpDelete("DeleteUser")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {

                return Ok(await _userService.DeleteUser(id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ErrorResponse { Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ErrorResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Internal Server Error" });
            }
        }


        [HttpPut("ChangePassword")]
        public async Task<ActionResult> ChangePassword(ChangePasswordDTO DTO)
        {
            try
            {

                return Ok(await _userService.ChangePassword(DTO));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ErrorResponse { Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ErrorResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Internal Server Error" });
            }
        }



        [HttpGet("GetAllUsers")]
        public async Task<ActionResult> GetUsers()
        {
            try
            {

                return Ok(await _userService.GetAllUsers());
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ErrorResponse { Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ErrorResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Internal Server Error" });
            }
        }

        [HttpGet("GetSpecificUser")]
        public async Task<ActionResult> GetUser(int id)
        {
            try
            {

                return Ok(await _userService.GetUser(id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ErrorResponse { Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ErrorResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Internal Server Error" });
            }
        }
    }
}
