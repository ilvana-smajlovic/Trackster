using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;
using Trackster.Model;
using Trackster.Repository;

namespace Trackster.Services
{
    public class UserRoleService : BaseCRUDService<UserRoles, UserRoleSearchObject, UserRoleInsertRequest, UserRoleUpdateRequest>, IUserRoleService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public UserRoleService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual PagedResult<UserRoles> GetList(UserRoleSearchObject searchObject)
        {
            List<UserRoles> result = new List<UserRoles>();

            var query = Context.UserRoles.AsQueryable();

            if (searchObject?.user_id != null)
            {
                query = query.Where(x => x.user_id == searchObject.user_id);
            }

            if (searchObject?.role_id != null)
            {
                query = query.Where(x => x.role_id == searchObject.role_id);
            }

            int count = query.Count();


            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<UserRoles> response = new PagedResult<UserRoles>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public UserRoles Insert(UserRoleInsertRequest request)
        {
            UserRoles role = new UserRoles();
            Mapper.Map(request, role);

            Context.UserRoles.Add(role);
            Context.SaveChanges();

            return role;
        }

        public UserRoles GetById(int id)
        {
            var role = Context.UserRoles.Where(m => m.user_role_id == id).FirstOrDefault();
            if (role == null)
            {
                throw new Exception("Ne postoji id");
            }
            return role;
        }

        public UserRoles Update(UserRoleUpdateRequest request)
        {
            var role = Context.UserRoles.Find(request.user_role_id);
            if (role == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, role);
            Context.UserRoles.Update(role);
            Context.SaveChanges();

            return role;
        }

        public UserRoles Delete(int id)
        {
            var role = Context.UserRoles.Find(id);
            if (role == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.UserRoles.Remove(role);
            Context.SaveChanges();
            return role;
        }
    }
}
