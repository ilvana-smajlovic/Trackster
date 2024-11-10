using Microsoft.AspNetCore.Mvc;
using Trackster.Model;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;
using Trackster.Services;

namespace Trackster.API.Controllers
{
    public class UserRoleController : BaseCRUDController<UserRoles, UserRoleSearchObject, UserRoleInsertRequest, UserRoleUpdateRequest>
    {
        protected IUserRoleService _service;
        public UserRoleController(IUserRoleService service) : base(service)
        {
        }
    }
}
