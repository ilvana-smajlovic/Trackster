using Microsoft.AspNetCore.Mvc;
using Trackster.Model;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;
using Trackster.Services;

namespace Trackster.API.Controllers
{
    public class GenreMediaController : BaseCRUDController<GenreMedia, GenreMediaSearchObject, GenreMediaInsertRequest, GenreMediaUpdateRequest>
    {
        protected IGenreMediaService _service;
        public GenreMediaController(IGenreMediaService service) : base(service)
        {

        }
    }
}
