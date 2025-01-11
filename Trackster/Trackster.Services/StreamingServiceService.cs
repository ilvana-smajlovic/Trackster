using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model.Requests;
using Trackster.Model;
using Trackster.Repository;
using System.Globalization;
using Trackster.Model.SearchObjects;

namespace Trackster.Services
{
    public class StreamingServiceService : BaseCRUDService<StreamingServices, NameSearchObject, StreamingServiceInsertRequest, StreamingServiceUpdateRequest>, IStreamingServiceService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public StreamingServiceService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual PagedResult<StreamingServices> GetList(NameSearchObject searchObject)
        {
            List<StreamingServices> result = new List<StreamingServices>();

            var query = Context.StreamingServices.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchObject?.name))
            {
                query = query.Where(x => x.service_name.StartsWith(searchObject.name));
            }

            int count = query.Count();


            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<StreamingServices> response = new PagedResult<StreamingServices>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public StreamingServices Insert(StreamingServiceInsertRequest request)
        {
            StreamingServices service = new StreamingServices();
            Mapper.Map(request, service);

            Context.StreamingServices.Add(service);
            Context.SaveChanges();

            return service;
        }

        public StreamingServices GetById(int id)
        {
            var service = Context.StreamingServices.Where(m => m.streaming_service_id == id).FirstOrDefault();
            if (service == null)
            {
                throw new Exception("Ne postoji id");
            }
            return service;
        }

        public StreamingServices Update(StreamingServices request)
        {
            var service = Context.StreamingServices.Find(request.streaming_service_id);
            if (service == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, service);
            Context.StreamingServices.Update(service);
            Context.SaveChanges();

            return service;
        }

        public StreamingServices Delete(int id)
        {
            var service = Context.StreamingServices.Find(id);
            if (service == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.StreamingServices.Remove(service);
            Context.SaveChanges();
            return service;
        }
    }
}
