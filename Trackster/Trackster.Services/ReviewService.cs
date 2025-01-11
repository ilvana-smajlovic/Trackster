using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model.Requests;
using Trackster.Model;
using Trackster.Repository;
using Trackster.Model.SearchObjects;

namespace Trackster.Services
{
    public class ReviewService : BaseCRUDService<Reviews, ReviewSearchObject, ReviewInsertRequest, ReviewUpdateRequest>, IReviewService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public ReviewService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual PagedResult<Reviews> GetList(ReviewSearchObject searchObject)
        {
            List<Reviews> result = new List<Reviews>();

            var query = Context.Reviews.AsQueryable();

            if (searchObject?.user_id != null)
            {
                query = query.Where(x => x.user_id == searchObject.user_id);
            }

            if (searchObject?.media_id != null)
            {
                query = query.Where(x => x.media_id == searchObject.media_id);
            }

            if (searchObject?.rating != null)
            {
                query = query.Where(x => x.rating == searchObject.rating);
            }

            if (searchObject?.isApproved != false)
            {
                query = query.Where(x => x.isApproved == searchObject.isApproved);
            }

            int count = query.Count();


            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<Reviews> response = new PagedResult<Reviews>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public Reviews Insert(ReviewInsertRequest request)
        {
            Reviews review = new Reviews();
            Mapper.Map(request, review);

            Context.Reviews.Add(review);
            Context.SaveChanges();

            return review;
        }

        public Reviews GetById(int id)
        {
            var review = Context.Reviews.Where(m => m.review_id == id).FirstOrDefault();
            if (review == null)
            {
                throw new Exception("Ne postoji id");
            }
            return review;
        }

        public Reviews Update(ReviewUpdateRequest request)
        {
            var review = Context.Reviews.Find(request.review_id);
            if (review == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, review);
            Context.Reviews.Update(review);
            Context.SaveChanges();

            return review;
        }

        public Reviews Delete(int id)
        {
            var review = Context.Reviews.Find(id);
            if (review == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.Reviews.Remove(review);
            Context.SaveChanges();
            return review;
        }
    }
}
