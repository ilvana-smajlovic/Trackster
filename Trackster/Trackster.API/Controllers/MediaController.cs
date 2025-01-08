using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using Trackster.Model;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;
using Trackster.Services;

namespace Trackster.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MediaController : BaseCRUDController<Media, MediaSearchObject, MediaInsertRequest, MediaUpdateRequest>
    {
        protected IMediaService _service;
        public MediaController(IMediaService service) : base(service) 
        {
            _service = service;
        }

        [HttpPut("{id}/activate")]
        public Media Activate(int id)
        {
            return (_service as IMediaService).Activate(id);
        }

        [HttpPut("{id}/edit")]
        public Media Edit(int id)
        {
            return (_service as IMediaService).Edit(id);
        }

        [HttpPut("{id}/hide")]
        public Media Hide(int id)
        {
            return (_service as IMediaService).Hide(id);
        }

        [HttpGet("{id}/allowedActions")]
        public List<string> AllowedActions(int id)
        {
            return (_service as IMediaService).AllowedActions(id);
        }
    }
}
