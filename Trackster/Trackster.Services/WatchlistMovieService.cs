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
    public class WatchlistMovieService : BaseCRUDService<WatchlistMovie, WatchlistMovieSearchObject, WatchlistMovieInsertRequest, WatchlistMovieUpdateRequest>, IWatchlistMovieService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public WatchlistMovieService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public virtual PagedResult<WatchlistMovie> GetList(WatchlistMovieSearchObject searchObject)
        {
            List<WatchlistMovie> result = new List<WatchlistMovie>();

            var query = Context.WatchlistMovie.AsQueryable();

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
                query = query.Where(x => x.movie.media.title.StartsWith(searchObject.title)).Include(x => x.movie.media);
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

            PagedResult<WatchlistMovie> response = new PagedResult<WatchlistMovie>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public WatchlistMovie Insert(WatchlistMovieInsertRequest request)
        {
            WatchlistMovie movie = new WatchlistMovie();
            Mapper.Map(request, movie);

            movie.added_at = DateTime.Now;

            Context.WatchlistMovie.Add(movie);
            Context.SaveChanges();

            return movie;
        }

        public WatchlistMovie GetById(int id)
        {
            var movie = Context.WatchlistMovie.Where(m => m.watclist_movie_id == id).FirstOrDefault();
            if (movie == null)
            {
                throw new Exception("Ne postoji id");
            }
            return movie;
        }

        public WatchlistMovie Update(WatchlistMovieUpdateRequest request)
        {
            var movie = Context.WatchlistMovie.Find(request.watclist_movie_id);
            if (movie == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, movie);
            Context.WatchlistMovie.Update(movie);
            Context.SaveChanges();

            return movie;
        }

        public WatchlistMovie Delete(int id)
        {
            var movie = Context.WatchlistMovie.Find(id);
            if (movie == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.WatchlistMovie.Remove(movie);
            Context.SaveChanges();
            return movie;
        }
    }
}
