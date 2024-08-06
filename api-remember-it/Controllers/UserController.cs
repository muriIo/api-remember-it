using api_remember_it.DTOs;
using api_remember_it.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace api_remember_it.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [Route("Register")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerResponse(statusCode: 200, description: "Works correctly.", type: typeof(ResponseDTO))]
        [SwaggerResponse(statusCode: 400, description: "Internal Error.", type: typeof(ResponseDTO))]
        [SwaggerOperation(OperationId = "POST", Summary = "auth", Description = "Register User.")]
        public ActionResult Register(CreateUserDTO user)
        {
            try
            {
                _logger.LogInformation("Creating user");
                _userService.Register(user);

                ResponseDTO response = new ResponseDTO();
                response.Status = "Ok"; 
                response.Message = "User sucessfully create";

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ex: " + ex.Message + " - Stack: " + ex.StackTrace);
                ResponseDTO response = new ResponseDTO();
                response.Status = "Error"; 
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
