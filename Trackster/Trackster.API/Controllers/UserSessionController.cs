using Microsoft.AspNetCore.Mvc;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;
using Trackster.Model;
using Trackster.Services;

namespace Trackster.API.Controllers
{
    public class UserSessionController : BaseCRUDController<UserSessions, UserSessionSearchObject, UserSessionInsertRequest, UserSessionUpdateRequest>
    {
        protected IUserSessionService _service;
        public UserSessionController(IUserSessionService service) : base(service)
        {

        }
    }
}
