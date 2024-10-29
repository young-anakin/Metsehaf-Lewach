using LewachBookTrading.DTOs.FriendDTO;
using LewachBookTrading.DTOs.JournalDTO;
using LewachBookTrading.Model;
using LewachBookTrading.Services.FriendService;
using LewachBookTrading.Services.JournalService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LewachBookTrading.Controllers
{
    public class FrienshipController : Controller
    {
        private readonly IFriendService _friendService;

        public FrienshipController(IFriendService friendService)
        {
            _friendService = friendService;
        }
        //Add a new Employee 
        [HttpPost("AddFriendship")]
        public async Task<ActionResult> AddEmployee(AddFriendDTO DTO)
        {
            try
            {
                return Ok(await _friendService.AddFriendship(DTO));
            }
            //return Ok(await _employeeService.AddEmployee(employeeDTO));            }
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
            catch (DbUpdateException ex)
            {
                // Handle database update related exceptions specifically
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Database update error: " + ex.InnerException?.Message });
            }
            catch (NullReferenceException ex)
            {
                // Handle null reference exceptions
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Null reference error: " + ex.Message });
            }
            catch (Exception ex)
            {
                // Log the exception details for further analysis
                // Use your logging framework here
                Console.WriteLine(ex); // or a logger

                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "An unexpected error occurred. Please try again later." });
            }
        }
    }
}
