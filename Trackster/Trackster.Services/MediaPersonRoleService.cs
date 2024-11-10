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
    public class MediaPersonRoleService : BaseCRUDService<MediaPersonCrewRole, MediaPersonRoleSearchObject, MediaPersonRoleInsertRequest,  MediaPersonRoleUpdateRequest>, IMediaPersonRoleService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public MediaPersonRoleService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual PagedResult<MediaPersonCrewRole> GetList(MediaPersonRoleSearchObject searchObject)
        {
            List<MediaPersonCrewRole> result = new List<MediaPersonCrewRole>();

            var query = Context.MediaPersonRole.AsQueryable();

            if (searchObject?.media_id != null)
            {
                query = query.Where(x => x.media_id == searchObject.media_id).Include(x => x.media);
            }

            if (searchObject?.person_id != null)
            {
                query = query.Where(x => x.person_id == searchObject.person_id).Include(x => x.person);
            }

            if (searchObject?.role_id != null)
            {
                query = query.Where(x => x.crew_role_id == searchObject.role_id).Include(x => x.crew_role);
            }

            int count = query.Count();


            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<MediaPersonCrewRole> response = new PagedResult<MediaPersonCrewRole>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public MediaPersonCrewRole Insert(MediaPersonRoleInsertRequest request)
        {
            MediaPersonCrewRole mpr = new MediaPersonCrewRole();
            Mapper.Map(request, mpr);

            Context.MediaPersonRole.Add(mpr);
            Context.SaveChanges();

            return mpr;
        }

        public MediaPersonCrewRole GetById(int id)
        {
            var mpr = Context.MediaPersonRole.Where(m => m.mediapersonrole_id == id).FirstOrDefault();
            if (mpr == null)
            {
                throw new Exception("Ne postoji id");
            }
            return mpr;
        }

        public MediaPersonCrewRole Update(MediaPersonRoleUpdateRequest request)
        {
            var mpr = Context.MediaPersonRole.Find(request.mediapersonrole_id);
            if (mpr == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, mpr);
            Context.MediaPersonRole.Update(mpr);
            Context.SaveChanges();

            return mpr;
        }

        public MediaPersonCrewRole Delete(int id)
        {
            var mpr = Context.MediaPersonRole.Find(id);
            if (mpr == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.MediaPersonRole.Remove(mpr);
            Context.SaveChanges();
            return mpr;
        }
    }
}
