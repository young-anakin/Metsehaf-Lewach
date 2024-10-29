using LewachBookTrading.DTOs.JournalDTO;
using LewachBookTrading.DTOs.JournalTypesDTO;
using LewachBookTrading.Model;
using LewachBookTrading.Services.JournalService;
using LewachBookTrading.Services.JournalTypeService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LewachBookTrading.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : Controller
    {
        private readonly IJournalService _journalService;

        public JournalController(IJournalService journalService)
        {
            _journalService = journalService;
        }
        //Add a new Employee 
        [HttpPost("AddJournal")]
        public async Task<ActionResult> AddEmployee(AddJournalDTO DTO)
        {
            try
            {
                return Ok(await _journalService.AddJournal(DTO));
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
        [HttpGet("GetSpecificJournal")]
        public async Task<ActionResult> GetSpecificJournal(int journalId)
        {
            try
            {
                return Ok(await _journalService.GetSpecificJournal(journalId));
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

        [HttpGet("GetUserJournals")]
        public async Task<ActionResult> GetJournalOfuser(int userid)
        {
            try
            {
                return Ok(await _journalService.GetJournalsByUser(userid));
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
