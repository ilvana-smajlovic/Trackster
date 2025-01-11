using Azure.Core;
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
    public class LanguageService : BaseCRUDService<Languages, NameSearchObject, LanguageInsertRequest, LanguageUpdateRequest>, ILanguageService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public LanguageService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual PagedResult<Languages> GetList(NameSearchObject searchObject)
        {
            List<Languages> result = new List<Languages>();

            var query = Context.Languages.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchObject?.name))
            {
                query = query.Where(x => x.language_name.StartsWith(searchObject.name));
            }

            int count = query.Count();


            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<Languages> response = new PagedResult<Languages>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public Languages Insert(LanguageInsertRequest request)
        {
            Languages language = new Languages();
            Mapper.Map(request, language);

            Context.Languages.Add(language);
            Context.SaveChanges();

            return language;
        }

        public Languages GetById(int id)
        {
            var language = Context.Languages.Where(m => m.language_id == id).FirstOrDefault();
            if (language == null)
            {
                throw new Exception("Ne postoji id");
            }
            return language;
        }

        public Languages Update(LanguageUpdateRequest request)
        {
            var language = Context.Languages.Find(request.language_id);
            if (language == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, language);
            Context.Languages.Update(language);
            Context.SaveChanges();

            return language;
        }

        public Languages Delete(int id)
        {
            var language = Context.Languages.Find(id);
            if (language == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.Languages.Remove(language);
            Context.SaveChanges();
            return language;
        }
    }
}
