using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;
using Trackster.Model;
using MapsterMapper;
using Trackster.Repository;
using Microsoft.EntityFrameworkCore;

namespace Trackster.Services
{
    public class UserSessionService : BaseCRUDService<UserSessions, UserSessionSearchObject, UserSessionInsertRequest, UserSessionUpdateRequest>, IUserSessionService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public UserSessionService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual PagedResult<UserSessions> GetList(UserSessionSearchObject searchObject)
        {
            List<UserSessions> result = new List<UserSessions>();

            var query = Context.UserSessions.AsQueryable();

            if (searchObject?.session_id != null)
            {
                query = query.Where(x => x.session_id == searchObject.session_id);
            }

            if (searchObject?.user_id != null)
            {
                query = query.Where(x => x.user_id == searchObject.user_id).Include(x => x.user);
            }

            int count = query.Count();

            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<UserSessions> response = new PagedResult<UserSessions>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public UserSessions Insert(UserSessionInsertRequest request)
        {
            UserSessions session = new UserSessions();
            Mapper.Map(request, session);

            Context.UserSessions.Add(session);
            Context.SaveChanges();

            return session;
        }

        public UserSessions GetById(int id)
        {
            var session = Context.UserSessions.Where(m => m.session_id == id).FirstOrDefault();
            if (session == null)
            {
                throw new Exception("Ne postoji id");
            }
            return session;
        }

        public UserSessions Update(UserSessionUpdateRequest request)
        {
            var session = Context.UserSessions.Find(request.session_id);
            if (session == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, session);
            Context.UserSessions.Update(session);
            Context.SaveChanges();

            return session;
        }

        public UserSessions Delete(int id)
        {
            var session = Context.UserSessions.Find(id);
            if (session == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.UserSessions.Remove(session);
            Context.SaveChanges();
            return session;
        }
    }
}
