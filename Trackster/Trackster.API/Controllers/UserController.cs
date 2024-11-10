using Microsoft.AspNetCore.Mvc;
using Trackster.Model.Requests;
using Trackster.Model;
using Trackster.Services;
using Trackster.Model.SearchObjects;
using Microsoft.AspNetCore.Authorization;

namespace Trackster.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class UserController : BaseCRUDController<Users, UserSearchObject, UserInsertRequest, UserUpdateRequest>
    {
        protected IUserService _service;
        public UserController(IUserService service) : base(service)
        {
            [HttpPost("login")]
            [AllowAnonymous]
            Users Login(string username, string password)
            {
                return (_service as IUserService).Login(username, password);
            }
        }

    }
}
