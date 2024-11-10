using Microsoft.AspNetCore.Mvc;
using Trackster.Model.Requests;
using Trackster.Model;
using Trackster.Services;
using Trackster.Model.SearchObjects;

namespace Trackster.API.Controllers
{
    public class LanguageController : BaseCRUDController<Languages, NameSearchObject, LanguageInsertRequest, LanguageUpdateRequest>
    {
        protected ILanguageService _service;
        public LanguageController(ILanguageService service) : base(service)
        {
           
        }

    }
}
