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
    public class TokenService : BaseCRUDService<Tokens, TokenSearchObject, TokenInsertRequest, TokenUpdateRequest>, ITokenService
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public TokenService(TracksterContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual PagedResult<Tokens> GetList(TokenSearchObject searchObject)
        {
            List<Tokens> result = new List<Tokens>();

            var query = Context.Tokens.AsQueryable();

            if (searchObject?.token_id != null)
            {
                query = query.Where(x => x.token_id == searchObject.token_id);
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

            PagedResult<Tokens> response = new PagedResult<Tokens>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public Tokens Insert(TokenInsertRequest request)
        {
            Tokens token = new Tokens();
            Mapper.Map(request, token);

            Context.Tokens.Add(token);
            Context.SaveChanges();

            return token;
        }

        public Tokens GetById(int id)
        {
            var token = Context.Tokens.Where(m => m.token_id == id).FirstOrDefault();
            if (token == null)
            {
                throw new Exception("Ne postoji id");
            }
            return token;
        }

        public Tokens Update(TokenUpdateRequest request)
        {
            var token = Context.Tokens.Find(request.token_id);
            if (token == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, token);
            Context.Tokens.Update(token);
            Context.SaveChanges();

            return token;
        }

        public Tokens Delete(int id)
        {
            var token = Context.Tokens.Find(id);
            if (token == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.Tokens.Remove(token);
            Context.SaveChanges();
            return token;
        }
    }
}
