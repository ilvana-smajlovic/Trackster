using Microsoft.AspNetCore.Mvc;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;
using Trackster.Model;
using Trackster.Services;

namespace Trackster.API.Controllers
{
    public class TokenController : BaseCRUDController<Tokens, TokenSearchObject, TokenInsertRequest, TokenUpdateRequest>
    {
        protected ITokenService _service;
        public TokenController(ITokenService service) : base(service)
        { 
        }
    }
}
