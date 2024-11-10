using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model.Requests;
using Trackster.Model;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Trackster.Model.SearchObjects;

namespace Trackster.Services
{
    public interface ITVShowService : ICRUDService<TVShows, NameSearchObject, TVShowInsertRequest,  TVShowUpdateRequest>
    {

    }
}
