using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model.Requests;
using Trackster.Model;
using Trackster.Repository;
using Trackster.Model.SearchObjects;
using Microsoft.EntityFrameworkCore;

namespace Trackster.Services
{
    public class TVShowService : BaseCRUDService<TVShows, NameSearchObject, TVShowInsertRequest, TVShowUpdateRequest>, ITVShowService

    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public TVShowService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual PagedResult<TVShows> GetList(NameSearchObject searchObject)
        {
            List<TVShows> result = new List<TVShows>();

            var query = Context.TVShows.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchObject?.name))
            {
                query = query.Where(x => x.media.title.StartsWith(searchObject.name)).Include(m => m.media);
            }

            int count = query.Count();


            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<TVShows> response = new PagedResult<TVShows>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public TVShows Insert(TVShowInsertRequest request)
        {
            TVShows tvshow = new TVShows();
            Mapper.Map(request, tvshow);

            Context.TVShows.Add(tvshow);
            Context.SaveChanges();

            return tvshow;
        }

        public TVShows GetById(int id)
        {
            var tvshow = Context.TVShows.Where(m => m.tvshow_id == id).FirstOrDefault();
            if (tvshow == null)
            {
                throw new Exception("Ne postoji id");
            }
            return tvshow;
        }

        public TVShows Update(TVShowUpdateRequest request)
        {
            var tvshow = Context.TVShows.Find(request.tvshow_id);
            if (tvshow == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, tvshow);
            Context.TVShows.Update(tvshow);
            Context.SaveChanges();

            return tvshow;
        }

        public TVShows Delete(int id)
        {
            var tvshow = Context.TVShows.Find(id);
            if (tvshow == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.TVShows.Remove(tvshow);
            Context.SaveChanges();
            return tvshow;
        }
    }
}
