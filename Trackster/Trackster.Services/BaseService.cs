using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model;
using Trackster.Model.SearchObjects;
using Trackster.Repository;

namespace Trackster.Services
{
    public class BaseService<TModel, TSearch> : IService<TModel, TSearch> where TSearch : BaseSearchObject where TModel : class
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public BaseService(TracksterContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public PagedResult<TModel> GetPaged(TSearch search)
        {
            List<TModel> result = new List<TModel>();

            var query = Context.Set<TModel>().AsQueryable();

            query = AddFilter(search, query);

            int count = query.Count();

            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                query = query.Skip(search.Page.Value * search.PageSize.Value).Take(search.PageSize.Value);
            }

            var list = query.ToList();

            result = Mapper.Map(list, result);

            PagedResult<TModel> pagedResult = new PagedResult<TModel>();
            pagedResult.ResultList = result;
            pagedResult.Count = count;

            return pagedResult;
        }

        public virtual IQueryable<TModel> AddFilter(TSearch search, IQueryable<TModel> query)
        {
            return query;
        }

        public TModel GetById(int id)
        {
            var entity = Context.Set<TModel>().Find(id);

            if (entity != null)
            {
                return Mapper.Map<TModel>(entity);
            }
            else
            {
                return null;
            }

        }
    }
}
