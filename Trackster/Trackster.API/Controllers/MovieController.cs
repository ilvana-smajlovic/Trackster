using Microsoft.AspNetCore.Mvc;
using Trackster.Model.Requests;
using Trackster.Model;
using Trackster.Services;
using Trackster.Model.SearchObjects;

namespace Trackster.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MovieController : BaseCRUDController<Movies, NameSearchObject, MovieInsertRequest, MovieUpdateRequest>
    {
        protected IMovieService _service;
        public MovieController(IMovieService service) : base(service)
        {
        }

    }
}
