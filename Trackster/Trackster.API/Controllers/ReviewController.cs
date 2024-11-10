using Microsoft.AspNetCore.Mvc;
using Trackster.Model.Requests;
using Trackster.Model;
using Trackster.Services;
using Trackster.Model.SearchObjects;

namespace Trackster.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReviewController : BaseCRUDController<Reviews, ReviewSearchObject, ReviewInsertRequest, ReviewUpdateRequest>
    {
        protected IReviewService _service;
        public ReviewController(IReviewService service) : base(service)
        {
        }


    }
}
