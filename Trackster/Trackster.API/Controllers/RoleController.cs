using Microsoft.AspNetCore.Mvc;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;
using Trackster.Model;
using Trackster.Services;

namespace Trackster.API.Controllers
{
    public class RoleController : BaseCRUDController<Roles, NameSearchObject, RoleInsertRequest, RoleUpdateRequest>
    {
        protected IRoleService _service;
        public RoleController(IRoleService service) : base(service)
        {
        }
    }
}
