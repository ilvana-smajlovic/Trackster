using Microsoft.AspNetCore.Mvc;
using Trackster.Model.Requests;
using Trackster.Model;
using Trackster.Services;
using Trackster.Model.SearchObjects;

namespace Trackster.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CrewRoleController : BaseCRUDController<CrewRoles, NameSearchObject, CrewRoleInsertRequest, CrewRoleUpdateRequest>
    {
        protected ICrewRoleService _service;
        public CrewRoleController(ICrewRoleService service) : base(service)
        {
        }

    }
}
