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
    public class RoleService : BaseCRUDService<Roles, NameSearchObject, RoleInsertRequest, RoleUpdateRequest>, IRoleService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public RoleService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual PagedResult<Roles> GetList(NameSearchObject searchObject)
        {
            List<Roles> result = new List<Roles>();

            var query = Context.Roles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchObject?.name))
            {
                query = query.Where(x => x.role_name.StartsWith(searchObject.name));
            }


            int count = query.Count();


            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<Roles> response = new PagedResult<Roles>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public Roles Insert(RoleInsertRequest request)
        {
            Roles role = new Roles();
            Mapper.Map(request, role);

            Context.Roles.Add(role);
            Context.SaveChanges();

            return role;
        }

        public Roles GetById(int id)
        {
            var role = Context.Roles.Where(m => m.role_id == id).FirstOrDefault();
            if (role == null)
            {
                throw new Exception("Ne postoji id");
            }
            return role;
        }

        public Roles Update(CrewRoleUpdateRequest request)
        {
            var role = Context.Roles.Find(request.role_id);
            if (role == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, role);
            Context.Roles.Update(role);
            Context.SaveChanges();

            return role;
        }

        public Roles Delete(int id)
        {
            var role = Context.Roles.Find(id);
            if (role == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.Roles.Remove(role);
            Context.SaveChanges();
            return role;
        }
    }
}
