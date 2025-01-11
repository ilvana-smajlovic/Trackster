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
    public class GenreMediaService : BaseCRUDService<GenreMedia, GenreMediaSearchObject, GenreMediaInsertRequest, GenreMediaUpdateRequest>, IGenreMediaService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public GenreMediaService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual PagedResult<GenreMedia> GetList(GenreMediaSearchObject searchObject)
        {
            List<GenreMedia> result = new List<GenreMedia>();

            var query = Context.GenreMedia.AsQueryable();

            if (searchObject?.genre_id != null)
            {
                query = query.Where(x => x.genre_id == searchObject.genre_id);
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.genre_name))
            {
                query = query.Where(x => x.genre.genre_name.StartsWith(searchObject.genre_name));
            }

            if (searchObject?.media_id != null)
            {
                query = query.Where(x => x.media_id == searchObject.media_id);
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.title))
            {
                query = query.Where(x => x.media.title.StartsWith(searchObject.title));
            }

            int count = query.Count();


            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<GenreMedia> response = new PagedResult<GenreMedia>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public GenreMedia Insert(GenreMediaInsertRequest request)
        {
            GenreMedia genre_media = new GenreMedia();
            Mapper.Map(request, genre_media);

            Context.GenreMedia.Add(genre_media);
            Context.SaveChanges();

            return genre_media;
        }

        public GenreMedia GetById(int id)
        {
            var genre_media = Context.GenreMedia.Where(m => m.genremedia_id == id).FirstOrDefault();
            if (genre_media == null)
            {
                throw new Exception("Ne postoji id");
            }
            return genre_media;
        }

        public GenreMedia Update(GenreMediaUpdateRequest request)
        {
            var genre_media = Context.GenreMedia.Find(request.genre_media_id);
            if (genre_media == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, genre_media);
            Context.GenreMedia.Update(genre_media);
            Context.SaveChanges();

            return genre_media;
        }

        public GenreMedia Delete(int id)
        {
            var genre_media = Context.GenreMedia.Find(id);
            if (genre_media == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.GenreMedia.Remove(genre_media);
            Context.SaveChanges();
            return genre_media;
        }
    }
}
