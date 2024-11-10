using Azure.Core;
using MapsterMapper;
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
    public class GenreService : BaseCRUDService<Genres, NameSearchObject, GenreInsertRequest, GenreUpdateRequest>, IGenreService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public GenreService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual PagedResult<Genres> GetList(NameSearchObject searchObject)
        {
            List<Genres> result = new List<Genres>();

            var query = Context.Genres.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchObject?.name))
            {
                query = query.Where(x => x.genre_name.StartsWith(searchObject.name));
            }

            int count = query.Count();


            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<Genres> response = new PagedResult<Genres>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public Genres Insert(GenreInsertRequest request)
        {
            Genres genre = new Genres();
            Mapper.Map(request, genre);

            Context.Genres.Add(genre);
            Context.SaveChanges();

            return genre;
        }

        public Genres GetById(int id)
        {
            var genre = Context.Genres.Where(m => m.genre_id == id).FirstOrDefault();
            if (genre == null)
            {
                throw new Exception("Ne postoji id");
            }
            return genre;
        }

        public Genres Update(GenreUpdateRequest request)
        {
            var genre = Context.Genres.Find(request.genre_id);
            if (genre == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, genre);
            Context.Genres.Update(genre);
            Context.SaveChanges();

            return genre;
        }

        public Genres Delete(int id)
        {
            var genre = Context.Genres.Find(id);
            if (genre == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.Genres.Remove(genre);
            Context.SaveChanges();
            return genre;
        }
    }
}
