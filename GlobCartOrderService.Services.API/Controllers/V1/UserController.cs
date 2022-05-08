using AutoMapper;
using GlobCartOrderService.Domain.Models;
using GlobCartOrderService.Services.API.Models;
using GlobCartOrderService.Services.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlobCartOrderService.Services.API.Controllers.V1
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public readonly IMapper _mapper;
        public readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Produces(typeof(User))]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Retornando lista de usuários completa");
            var users = _userService.GetUsers();

            return Ok(users);
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), 201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<UserViewModel> Create([FromBody]CreateUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userResult = _userService.CreateUser(_mapper.Map<User>(user));
                if (userResult.IsValid)
                    return Created($"api/users/{userResult.Model.Name}", _mapper.Map<UserViewModel>(userResult.Model));
                else
                    return BadRequest(userResult.Errors);
            }

            return BadRequest(ModelState);
        }
    }
}
