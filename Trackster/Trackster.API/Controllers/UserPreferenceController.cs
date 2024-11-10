using Microsoft.AspNetCore.Mvc;
using Trackster.Model;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;
using Trackster.Services;

namespace Trackster.API.Controllers
{
    public class UserPreferenceController : BaseCRUDController<UserPreferences, UserPreferenceSearchObject, UserPreferenceInsertRequest, UserPreferenceUpdateRequest>
    {
        protected IUserPreferenceService _service;
        public UserPreferenceController(IUserPreferenceService service) : base(service)
        {

        }
    }
}
