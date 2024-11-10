using Azure.Core;
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
    public class NotificationService : BaseCRUDService<Notifications, NotificationSearchObject, NotificationInsertRequest, NotificationUpdateRequest>, INotificationService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public NotificationService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual PagedResult<Notifications> GetList(NotificationSearchObject searchObject)
        {
            List<Notifications> result = new List<Notifications>();

            var query = Context.Notifications.AsQueryable();

            if (searchObject?.user_id != null)
            {
                query = query.Where(x => x.user_id == searchObject.user_id);
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.title))
            {
                query = query.Where(x => x.title.StartsWith(searchObject.title));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.message))
            {
                query = query.Where(x => x.message.StartsWith(searchObject.message));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.notification_type))
            {
                query = query.Where(x => x.notification_type.StartsWith(searchObject.notification_type));
            }

            if (searchObject?.isSent == true)
            {
                query = query.Where(x => x.isSent == searchObject.isSent);
            }

            int count = query.Count();


            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<Notifications> response = new PagedResult<Notifications>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public Notifications Insert(NotificationInsertRequest request)
        {
            Notifications notification = new Notifications();
            Mapper.Map(request, notification);

            Context.Notifications.Add(notification);
            Context.SaveChanges();

            return notification;
        }

        public Notifications GetById(int id)
        {
            var notification = Context.Notifications.Where(m => m.notification_id == id).FirstOrDefault();
            if (notification == null)
            {
                throw new Exception("Ne postoji id");
            }
            return notification;
        }

        public Notifications Update(NotificationUpdateRequest request)
        {
            var notification = Context.Notifications.Find(request.notification_id);
            if (notification == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, notification);
            Context.Notifications.Update(notification);
            Context.SaveChanges();

            return notification;
        }

        public Notifications Delete(int id)
        {
            var notification = Context.Notifications.Find(id);
            if (notification == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.Notifications.Remove(notification);
            Context.SaveChanges();
            return notification;
        }
    }
}
