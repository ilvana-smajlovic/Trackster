using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;
using Trackster.Repository;
using Trackster.Services.MediaStateMachine;

namespace Trackster.Services
{
    public class MediaService : BaseCRUDService<Media, MediaSearchObject, MediaInsertRequest, MediaUpdateRequest>, IMediaService
    {
        public BaseMediaState BaseMediaState { get; set; }

        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }
        
        ILogger<MediaService> _logger { get; set; }
        public MediaService(TracksterContext context, IMapper mapper, ILogger<MediaService> logger, BaseMediaState baseMediaState) : base(context, mapper)
        {
            _logger = logger;
            BaseMediaState = baseMediaState;
        }

        public virtual PagedResult<Media> GetList(MediaSearchObject searchObject)
        {
            List<Media> result = new List<Media>();

            var query = Context.Media.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchObject?.title))
            {
                query = query.Where(x => x.title.StartsWith(searchObject.title));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.status))
            {
                query = query.Where(x => x.status.StartsWith(searchObject.status));
            }

            if (searchObject?.rating != null)
            {
                query = query.Where(x => x.rating == searchObject.rating);
            }

            int count = query.Count();


            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<Media> response = new PagedResult<Media>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public Media Insert(MediaInsertRequest request)
        {
            Media media = new Media();
            Mapper.Map(request, media);

            Context.Media.Add(media);
            Context.SaveChanges();

            return media;
        }

        public Media GetById(int id)
        {
            var media = Context.Media.Where(m => m.media_id == id).FirstOrDefault();
            if (media == null)
            {
                throw new Exception("Ne postoji id");
            }
            return media;
        }

        public Media Update(MediaUpdateRequest request)
        {
            var media = Context.Media.Find(request.media_id);
            if (media == null) {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, media);
            Context.Media.Update(media);
            Context.SaveChanges();

            return media;
        }

        public Media Delete(int id)
        {
            var media = Context.Media.Find(id);
            if (media == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.Media.Remove(media);
            Context.SaveChanges();
            return media;
        }

        public Media Activate(int id)
        {
            var entity = GetById(id);
            var state = BaseMediaState.CreateState(entity.state_machine);
            return state.Activate(id);
        }

        public Media Edit(int id)
        {
            var entity = GetById(id);
            var state = BaseMediaState.CreateState(entity.state_machine);
            return state.Edit(id);
        }

        public Media Hide(int id)
        {
            var entity = GetById(id);
            var state = BaseMediaState.CreateState(entity.state_machine);
            return state.Hide(id);
        }

        public List<string> AllowedActions(int id)
        {
            _logger.LogInformation($"Allowed actions called for: {id}");

            if (id <= 0)
            {
                var state = BaseMediaState.CreateState("initial");
                return state.AllowedActions(null);
            }
            else
            {
                var entity = Context.Media.Find(id);
                var state = BaseMediaState.CreateState(entity.state_machine);
                return state.AllowedActions(entity);
            }
        }
    }
}
