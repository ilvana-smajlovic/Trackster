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
    public class UserFollowService : BaseCRUDService<UserFollow, UserFollowSearchObject, UserFollowInsertRequest, UserFollowUpdateRequest>, IUserFollowService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public UserFollowService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual PagedResult<UserFollow> GetList(UserFollowSearchObject searchObject)
        {
            List<UserFollow> result = new List<UserFollow>();

            var query = Context.UserFolllow.AsQueryable();

            if (searchObject?.follow_id != null)
            {
                query = query.Where(x => x.follow_id == searchObject.follow_id);
            }

            if (searchObject?.follower_id != null)
            {
                query = query.Where(x => x.follower_id == searchObject.follower_id).Include(x => x.follower);
            }

            if (searchObject?.followed_user_id != null)
            {
                query = query.Where(x => x.followed_user_id == searchObject.followed_user_id).Include(x => x.followed_user);
            }

            int count = query.Count();


            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<UserFollow> response = new PagedResult<UserFollow>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public UserFollow Insert(UserFollowInsertRequest request)
        {
            UserFollow user = new UserFollow();
            Mapper.Map(request, user);

            Context.UserFolllow.Add(user);
            Context.SaveChanges();

            return user;
        }

        public UserFollow GetById(int id)
        {
            var user = Context.UserFolllow.Where(m => m.follow_id == id).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("Ne postoji id");
            }
            return user;
        }

        public UserFollow Update(UserFollowUpdateRequest request)
        {
            var user = Context.UserFolllow.Find(request.follow_id);
            if (user == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, user);
            Context.UserFolllow.Update(user);
            Context.SaveChanges();

            return user;
        }

        public UserFollow Delete(int id)
        {
            var user = Context.UserFolllow.Find(id);
            if (user == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.UserFolllow.Remove(user);
            Context.SaveChanges();
            return user;
        }
    }
}
