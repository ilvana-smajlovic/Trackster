using Microsoft.AspNetCore.Mvc;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;
using Trackster.Model;
using Trackster.Services;

namespace Trackster.API.Controllers
{
    public class UserFollowController : BaseCRUDController<UserFollow, UserFollowSearchObject, UserFollowInsertRequest, UserFollowUpdateRequest>
    {
        protected IUserFollowService _service;
        public UserFollowController(IUserFollowService service) : base(service)
        {
        }
    }
}
