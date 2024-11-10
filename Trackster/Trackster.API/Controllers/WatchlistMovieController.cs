using Microsoft.AspNetCore.Mvc;
using Trackster.Model.Requests;
using Trackster.Model;
using Trackster.Services;
using Trackster.Model.SearchObjects;

namespace Trackster.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WatchlistMovieController : BaseCRUDController<WatchlistMovie, WatchlistMovieSearchObject, WatchlistMovieInsertRequest, WatchlistMovieUpdateRequest>
    {
        protected IWatchlistMovieService _service;
        public WatchlistMovieController(IWatchlistMovieService service) : base(service)
        {
        }

    }
}
