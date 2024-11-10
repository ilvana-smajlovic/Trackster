using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;

namespace Trackster.Services
{
    public interface IMediaService : ICRUDService<Media, MediaSearchObject, MediaInsertRequest, MediaUpdateRequest>
    {
        public Media Activate(int id);
        public Media Edit(int id);
        public Media Hide(int id);
        public List<string> AllowedActions(int id);
    }
}
