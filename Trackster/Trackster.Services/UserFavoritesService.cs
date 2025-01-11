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
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;

namespace Trackster.Services
{
    public class UserFavoritesService : BaseCRUDService<UserFavorites, UserFavoriteSearchObject, UserFavoritesInsertRequest, UserFavoritesUpdateRequest>, IUserFavoritesService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public UserFavoritesService(TracksterContext context, IMapper mapper) : base(context, mapper) 
        {
            Context = context;
            Mapper = mapper;
        }
        public virtual PagedResult<UserFavorites> GetList(UserFavoriteSearchObject searchObject)
        {
            List<UserFavorites> result = new List<UserFavorites>();

            var query = Context.UserFavorites.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchObject?.username))
            {
                query = query.Where(x => x.user.username.StartsWith(searchObject.username)).Include(x => x.user);
            }

            int count = query.Count();


            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<UserFavorites> response = new PagedResult<UserFavorites>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public UserFavorites Insert(UserFavoritesInsertRequest request)
        {
            UserFavorites favorite = new UserFavorites();
         
            Mapper.Map(request, favorite);

            favorite.added_at = DateTime.Now;
            Context.UserFavorites.Add(favorite);
            Context.SaveChanges();

            return favorite;
        }

        public UserFavorites GetById(int id)
        {
            var favorite = Context.UserFavorites.Where(m => m.favorite_id == id).FirstOrDefault();
            if (favorite == null)
            {
                throw new Exception("Ne postoji id");
            }
            return favorite;
        }

        public UserFavorites Update(UserFavoritesUpdateRequest request)
        {
            var favorite = Context.UserFavorites.Find(request.favorite_id);
            if (favorite == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, favorite);
            Context.UserFavorites.Update(favorite);
            Context.SaveChanges();

            return favorite;
        }

        public UserFavorites Delete(int id)
        {
            var favorite = Context.UserFavorites.Find(id);
            if (favorite == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.UserFavorites.Remove(favorite);
            Context.SaveChanges();
            return favorite;
        }
    }
}
