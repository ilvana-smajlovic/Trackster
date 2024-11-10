using Microsoft.AspNetCore.Mvc;
using Trackster.Model.Requests;
using Trackster.Model;
using Trackster.Services;
using Trackster.Model.SearchObjects;

namespace Trackster.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserFavoritesController : BaseCRUDController<UserFavorites, UserFavoriteSearchObject, UserFavoritesInsertRequest, UserFavoritesUpdateRequest>
    {
        protected IUserFavoritesService _service;
        public UserFavoritesController(IUserFavoritesService service) : base(service)
        {
        }

    }
}
