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
    public class MediaStatisticsService : BaseCRUDService<MediaStatistics, MediaStatisticsSearchObject, MediaStatisticsInsertRequest, MediaStatisticsUpdateRequest>, IMediaStatisticsService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public MediaStatisticsService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual PagedResult<MediaStatistics> GetList(MediaStatisticsSearchObject searchObject)
        {
            List<MediaStatistics> result = new List<MediaStatistics>();

            var query = Context.MediaStatistics.AsQueryable();

            if (searchObject?.statistic_id != null)
            {
                query = query.Where(x => x.statistic_id == searchObject.statistic_id);
            }

            if (searchObject?.media_id != null)
            {
                query = query.Where(x => x.media_id == searchObject.media_id).Include(x => x.media);
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

            PagedResult<MediaStatistics> response = new PagedResult<MediaStatistics>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public MediaStatistics Insert(MediaStatisticsInsertRequest request)
        {
            MediaStatistics statistics = new MediaStatistics();
            Mapper.Map(request, statistics);

            Context.MediaStatistics.Add(statistics);
            Context.SaveChanges();

            return statistics;
        }

        public MediaStatistics GetById(int id)
        {
            var statistics = Context.MediaStatistics.Where(m => m.statistic_id == id).FirstOrDefault();
            if (statistics == null)
            {
                throw new Exception("Ne postoji id");
            }
            return statistics;
        }

        public MediaStatistics Update(MediaStatisticsUpdateRequest request)
        {
            var statistics = Context.MediaStatistics.Find(request.statistic_id);
            if (statistics == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, statistics);
            Context.MediaStatistics.Update(statistics);
            Context.SaveChanges();

            return statistics;
        }

        public MediaStatistics Delete(int id)
        {
            var statistics = Context.MediaStatistics.Find(id);
            if (statistics == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.MediaStatistics.Remove(statistics);
            Context.SaveChanges();
            return statistics;
        }
    }
}
