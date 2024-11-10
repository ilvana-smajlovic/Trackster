using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model.SearchObjects;
using Trackster.Repository;

namespace Trackster.Services
{
    public abstract class BaseCRUDService<TModel, TSearch, TInsert, TUpdate> : BaseService<TModel, TSearch> where TModel : class where TSearch : BaseSearchObject
    {
        public BaseCRUDService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual TModel Insert(TInsert request)
        {


            TModel entity = Mapper.Map<TModel>(request);

            BeforeInsert(request, entity);

            Context.Add(entity);
            Context.SaveChanges();


            return Mapper.Map<TModel>(entity);
        }

        public virtual void BeforeInsert(TInsert request, TModel entity) { }

        public virtual TModel Update(int id, TUpdate request)
        {
            var set = Context.Set<TModel>();

            var entity = set.Find(id);

            Mapper.Map(request, entity);

            BeforeUpdate(request, entity);
            
            Context.SaveChanges();

            return Mapper.Map<TModel>(entity);
        }

        public virtual void BeforeUpdate(TUpdate request, TModel entity) { }

    }
}
