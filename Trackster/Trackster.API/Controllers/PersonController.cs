using Microsoft.AspNetCore.Mvc;
using Trackster.Model.Requests;
using Trackster.Model;
using Trackster.Services;
using Trackster.Model.SearchObjects;

namespace Trackster.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonController : BaseCRUDController<People, PersonSearchObject, PersonInsertRequest, PersonUpdateRequest>
    {
        protected IPersonService _service;
        public PersonController(IPersonService service) : base(service)
        {
        }
        
    }
}
