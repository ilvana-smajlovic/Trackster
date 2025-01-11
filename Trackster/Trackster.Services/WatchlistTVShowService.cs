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
    public class WatchlistTVShowService : BaseCRUDService<WatchlistTVShow, WatchlistTVShowSearchObject, WatchlistTVShowInsertRequest, WatchlistTVShowUpdateRequest>, IWatchlistTVShowService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public WatchlistTVShowService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public virtual PagedResult<WatchlistTVShow> GetList(WatchlistTVShowSearchObject searchObject)
        {
            List<WatchlistTVShow> result = new List<WatchlistTVShow>();

            var query = Context.WatchlistTVShow.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchObject?.username))
            {
                query = query.Where(x => x.user.username.StartsWith(searchObject.username)).Include(x => x.user);
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.email))
            {
                query = query.Where(x => x.user.email.StartsWith(searchObject.email)).Include(x => x.user);
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.title))
            {
                query = query.Where(x => x.tvshow.media.title.StartsWith(searchObject.title)).Include(x => x.tvshow.media);
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.watch_state))
            {
                query = query.Where(x => x.watch_state.StartsWith(searchObject.watch_state));
            }

            int count = query.Count();


            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<WatchlistTVShow> response = new PagedResult<WatchlistTVShow>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public WatchlistTVShow Insert(WatchlistTVShowInsertRequest request)
        {
            WatchlistTVShow tvshow = new WatchlistTVShow();
            Mapper.Map(request, tvshow);

            tvshow.added_at = DateTime.Now;
            Context.WatchlistTVShow.Add(tvshow);
            Context.SaveChanges();

            return tvshow;
        }

        public WatchlistTVShow GetById(int id)
        {
            var tvshow = Context.WatchlistTVShow.Where(m => m.watchlist_tvshow_id == id).FirstOrDefault();
            if (tvshow == null)
            {
                throw new Exception("Ne postoji id");
            }
            return tvshow;
        }

        public WatchlistTVShow Update(WatchlistTVShowUpdateRequest request)
        {
            var tvshow = Context.WatchlistTVShow.Find(request.watchlist_tvshow_id);
            if (tvshow == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, tvshow);
            Context.WatchlistTVShow.Update(tvshow);
            Context.SaveChanges();

            return tvshow;
        }

        public WatchlistTVShow Delete(int id)
        {
            var tvshow = Context.WatchlistTVShow.Find(id);
            if (tvshow == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.WatchlistTVShow.Remove(tvshow);
            Context.SaveChanges();
            return tvshow;
        }
    }
}
