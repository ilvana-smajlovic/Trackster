using Microsoft.AspNetCore.Mvc;
using Trackster.Model;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;
using Trackster.Services;

namespace Trackster.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GenreController : BaseCRUDController<Genres, NameSearchObject, GenreInsertRequest, GenreUpdateRequest>
    {
        protected IGenreService _service;
        public GenreController(IGenreService service) : base(service)
        {

        }
    }
}
