using Microsoft.AspNetCore.Mvc;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;
using Trackster.Model;
using Trackster.Services;

namespace Trackster.API.Controllers
{
    public class MediaStatisticsController : BaseCRUDController<MediaStatistics, MediaStatisticsSearchObject, MediaStatisticsInsertRequest, MediaStatisticsUpdateRequest>
    {
        protected IMediaStatisticsService _service;
        public MediaStatisticsController(IMediaStatisticsService service) : base(service)
        {

        }
    }
}
