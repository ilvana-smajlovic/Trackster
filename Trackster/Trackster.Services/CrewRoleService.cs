using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model.Requests;
using Trackster.Model;
using Trackster.Repository;
using System.Data;
using Trackster.Model.SearchObjects;
using Microsoft.EntityFrameworkCore.Metadata;
using Trackster.Services.MediaStateMachine;

namespace Trackster.Services
{
    public class CrewRoleService : BaseCRUDService<CrewRoles, NameSearchObject, CrewRoleInsertRequest, CrewRoleUpdateRequest>, ICrewRoleService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public CrewRoleService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual PagedResult<CrewRoles> GetList(NameSearchObject searchObject)
        {
            List<CrewRoles> result = new List<CrewRoles>();

            var query = Context.CrewRoles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchObject?.name))
            {
                query = query.Where(x => x.crew_role_name.StartsWith(searchObject.name));
            }


            int count = query.Count();


            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<CrewRoles> response = new PagedResult<CrewRoles>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public CrewRoles Insert(CrewRoleInsertRequest request)
        {
            CrewRoles role = new CrewRoles();
            Mapper.Map(request, role);

            Context.CrewRoles.Add(role);
            Context.SaveChanges();

            return role;
        }

        public CrewRoles GetById(int id)
        {
            var role = Context.CrewRoles.Where(m => m.crew_role_id == id).FirstOrDefault();
            if (role == null)
            {
                throw new Exception("Ne postoji id");
            }
            return role;
        }

        public CrewRoles Update(CrewRoleUpdateRequest request)
        {
            var role = Context.CrewRoles.Find(request.role_id);
            if (role == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, role);
            Context.CrewRoles.Update(role);
            Context.SaveChanges();

            return role;
        }

        public CrewRoles Delete(int id)
        {
            var role = Context.CrewRoles.Find(id);
            if (role == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.CrewRoles.Remove(role);
            Context.SaveChanges();
            return role;
        }
    }
}
