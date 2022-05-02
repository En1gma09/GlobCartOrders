using AutoMapper;
using GlobCartOrderService.Domain.Models;
using GlobCartOrderService.Domain.Services;
using GlobCartOrderService.Services.API.Models;
using GlobCartOrderService.Services.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobCartOrderService.Services.API.Controllers.V1
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService userService;
        public readonly IMapper mapper;
        public readonly ILogger<UserController> logger;

        public UserController(IUserService userService, IMapper mapper, ILogger<UserController> logger)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), 201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<UserViewModel> Create([FromBody]CreateUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userResult = userService.CreateUser(mapper.Map<User>(user));
                if (userResult.IsValid)
                    return Created($"api/users/{userResult.Model.Name}", mapper.Map<UserViewModel>(userResult.Model));
                else
                    return BadRequest(userResult.Errors);
            }

            return BadRequest(ModelState);
        }
    }
}
