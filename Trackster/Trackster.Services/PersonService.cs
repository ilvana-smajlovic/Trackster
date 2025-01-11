using Azure.Identity;
using MapsterMapper;
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
    public class PersonService : BaseCRUDService<People, PersonSearchObject, PersonInsertRequest, PersonUpdateRequest>, IPersonService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public PersonService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual PagedResult<People> GetList(PersonSearchObject searchObject)
        {
            List<People> result = new List<People>();

            var query = Context.People.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchObject?.name))
            {
                query = query.Where(x => x.name.StartsWith(searchObject.name));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.last_name))
            {
                query = query.Where(x => x.last_name.StartsWith(searchObject.last_name));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.gender))
            {
                query = query.Where(x => x.gender.StartsWith(searchObject.gender));
            }

            int count = query.Count();


            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<People> response = new PagedResult<People>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public People Insert(PersonInsertRequest request)
        {
            People person = new People();
            Mapper.Map(request, person);

            Context.People.Add(person);
            Context.SaveChanges();

            return person;
        }

        public People GetById(int id)
        {
            var person = Context.People.Where(m => m.person_id == id).FirstOrDefault();
            if (person == null)
            {
                throw new Exception("Ne postoji id");
            }
            return person;
        }

        public People Update(PersonUpdateRequest request)
        {
            var person = Context.People.Find(request.person_id);
            if (person == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, person);
            Context.People.Update(person);
            Context.SaveChanges();

            return person;
        }

        public People Delete(int id)
        {
            var person = Context.People.Find(id);
            if (person == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.People.Remove(person);
            Context.SaveChanges();
            return person;
        }
    }
}