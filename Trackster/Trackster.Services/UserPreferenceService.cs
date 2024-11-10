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
    public class UserPreferenceService : BaseCRUDService<UserPreferences, UserPreferenceSearchObject, UserPreferenceInsertRequest, UserPreferenceUpdateRequest>, IUserPreferenceService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public UserPreferenceService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual PagedResult<UserPreferences> GetList(UserPreferenceSearchObject searchObject)
        {
            List<UserPreferences> result = new List<UserPreferences>();

            var query = Context.UserPreferences.AsQueryable();

            if (searchObject?.preference_id != null)
            {
                query = query.Where(x => x.preference_id == searchObject.preference_id);
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

            PagedResult<UserPreferences> response = new PagedResult<UserPreferences>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public UserPreferences Insert(UserPreferenceInsertRequest request)
        {
            UserPreferences preference = new UserPreferences();
            Mapper.Map(request, preference);

            Context.UserPreferences.Add(preference);
            Context.SaveChanges();

            return preference;
        }

        public UserPreferences GetById(int id)
        {
            var preference = Context.UserPreferences.Where(m => m.preference_id == id).FirstOrDefault();
            if (preference == null)
            {
                throw new Exception("Ne postoji id");
            }
            return preference;
        }

        public UserPreferences Update(UserPreferenceUpdateRequest request)
        {
            var preference = Context.UserPreferences.Find(request.preference_id);
            if (preference == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, preference);
            Context.UserPreferences.Update(preference);
            Context.SaveChanges();

            return preference;
        }

        public UserPreferences Delete(int id)
        {
            var preference = Context.UserPreferences.Find(id);
            if (preference == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.UserPreferences.Remove(preference);
            Context.SaveChanges();
            return preference;
        }
    }
}
