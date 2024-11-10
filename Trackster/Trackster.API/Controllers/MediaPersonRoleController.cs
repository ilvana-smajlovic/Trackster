using Microsoft.AspNetCore.Mvc;
using Trackster.Model;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;
using Trackster.Services;

namespace Trackster.API.Controllers
{
    public class MediaPersonRoleController : BaseCRUDController<MediaPersonCrewRole, MediaPersonRoleSearchObject, MediaPersonRoleInsertRequest, MediaPersonRoleUpdateRequest>
    {
        protected IMediaPersonRoleService _service;
        public MediaPersonRoleController(IMediaPersonRoleService service) : base(service)
        {

        }
    }
}
