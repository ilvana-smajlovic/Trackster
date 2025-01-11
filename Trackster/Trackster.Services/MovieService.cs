using Azure.Core;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;
using Trackster.Repository;

namespace Trackster.Services
{
    public class MovieService : BaseCRUDService<Movies, NameSearchObject, MovieInsertRequest, MovieUpdateRequest>, IMovieService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public MovieService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual PagedResult<Movies> GetList(NameSearchObject searchObject)
        {
            List<Movies> result = new List<Movies>();

            var query = Context.Movies.AsQueryable();

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

            PagedResult<Movies> response = new PagedResult<Movies>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public Movies Insert(MovieInsertRequest request)
        {
            Movies movie = new Movies();
            Mapper.Map(request, movie);

            Context.Movies.Add(movie);
            Context.SaveChanges();

            return movie;
        }

        public Movies GetById(int id)
        {
            var movie = Context.Movies.Where(m => m.movie_id == id).FirstOrDefault();
            if (movie == null)
            {
                throw new Exception("Ne postoji id");
            }
            return movie;
        }

        public Movies Update(MovieUpdateRequest request)
        {
            var movie = Context.Movies.Find(request.movie_id);
            if (movie == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, movie);
            Context.Movies.Update(movie);
            Context.SaveChanges();

            return movie;
        }

        public Movies Delete(int id)
        {
            var movie = Context.Movies.Find(id);
            if (movie == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.Movies.Remove(movie);
            Context.SaveChanges();
            return movie;
        }
    }
}
