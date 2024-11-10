using Microsoft.AspNetCore.Mvc;
using Trackster.Model.Requests;
using Trackster.Model;
using Trackster.Services;
using Trackster.Model.SearchObjects;

namespace Trackster.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WatchlistTVShowController : BaseCRUDController<WatchlistTVShow, WatchlistTVShowSearchObject, WatchlistTVShowInsertRequest, WatchlistTVShowUpdateRequest>
    {
        protected IWatchlistTVShowService _service;
        public WatchlistTVShowController(IWatchlistTVShowService service) : base(service)
        {

        }
    }
}
