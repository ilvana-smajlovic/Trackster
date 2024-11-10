using Microsoft.AspNetCore.Mvc;
using Trackster.Model.Requests;
using Trackster.Model;
using Trackster.Services;
using Trackster.Model.SearchObjects;

namespace Trackster.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StreamingServiceController : BaseCRUDController<StreamingServices, NameSearchObject, StreamingServiceInsertRequest, StreamingServiceUpdateRequest>
    {
        protected IStreamingServiceService _service;
        public StreamingServiceController(IStreamingServiceService service) : base(service)
        {
        }

    }
}
