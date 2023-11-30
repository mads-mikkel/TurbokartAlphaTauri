using Microsoft.AspNetCore.Mvc;
using Turbokart.Domain.Entities;
using static Turbokart.Presentation.Apis.TurbokartAPI.Controllers.BookingController;

namespace Turbokart.Presentation.Apis.TurbokartAPI.Controllers
{
    [Route("/userCheck")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserUseCase userUseCase;

        public UserController(IUserUseCase userUseCase)
        {
            this.userUseCase = userUseCase;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            try
            {
                var users = await userUseCase.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{bool}")]
        public async Task<ActionResult<bool>> DoesUserExist(string username, string password)
        {
            try
            {
                var user = await userUseCase.IsUserInSystem(username, password);
                if (user = true)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetBy(int id)
        {
            try
            {
                var user = await userUseCase.GetBy(id);
                if (user is null)
                {
                    return NotFound("Could not find a user with the id!");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{user}")]
        public async Task<ActionResult<User>> GetOneUsers(string username, string password)
        {
            try
            {
                var user = await userUseCase.GetOneUsers(username, password);
                if (user is null)
                {
                    return NotFound("Could not find a user with the id!");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            try
            {
                var newUser = await userUseCase.NewUser(user);
                return Created("Created new user", newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
