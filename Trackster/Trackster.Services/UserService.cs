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
using System.Diagnostics.Metrics;
using Microsoft.VisualStudio.Services.Users;
using System.Security.Cryptography;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Trackster.Services
{
    public class UserService : BaseCRUDService<Users, UserSearchObject, UserInsertRequest, UserUpdateRequest>, IUserService
    {
        ILogger<UserService> _logger;

        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public UserService(TracksterContext context, IMapper mapper, ILogger<UserService> logger) : base(context, mapper)
        {
            _logger = logger;
            Context = context;
            Mapper = mapper;
        }

        public virtual PagedResult<Users> GetList(UserSearchObject searchObject)
        {
            List<Users> result = new List<Users>();

            var query = Context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchObject?.username))
            {
                query = query.Where(x => x.username.StartsWith(searchObject.username));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.email))
            {
                query = query.Where(x => x.email.StartsWith(searchObject.email));
            }

            int count = query.Count();


            if (searchObject?.page.HasValue == true && searchObject?.page_size.HasValue == true)
            {
                query = query.Skip(searchObject.page.Value * searchObject.page_size.Value).Take(searchObject.page_size.Value);
            }

            var list = query.ToList();

            var resultList = Mapper.Map(list, result);

            PagedResult<Users> response = new PagedResult<Users>();

            response.ResultList = resultList;
            response.Count = count;

            return response;
        }

        public Users Insert(UserInsertRequest request)
        {
            Users user = new Users();
            Mapper.Map(request, user);

            Context.Users.Add(user);
            Context.SaveChanges();

            return user;
        }

        public Users GetById(int id)
        {
            var user = Context.Users.Where(m => m.user_id == id).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("Ne postoji id");
            }
            return user;
        }

        public Users Update(UserUpdateRequest request)
        {
            var user = Context.Users.Find(request.user_id);
            if (user == null)
            {
                throw new Exception("Ne postoji id");
            }

            Mapper.Map(request, user);
            Context.Users.Update(user);
            Context.SaveChanges();

            return user;
        }

        public Users Delete(int id)
        {
            var user = Context.Users.Find(id);
            if (user == null)
            {
                throw new Exception("Ne postoji id");
            }

            Context.Users.Remove(user);
            Context.SaveChanges();
            return user;
        }

        public override IQueryable<Users> AddFilter(UserSearchObject searchObject, IQueryable<Users> query)
        {
            query = base.AddFilter(searchObject, query);
            if (!string.IsNullOrWhiteSpace(searchObject?.username))
            {
                query = query.Where(x => x.username.StartsWith(searchObject.username));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.email))
            {
                query = query.Where(x => x.email == searchObject.email);
            }

            return query;
        }

        public override void BeforeInsert(UserInsertRequest request, Users entity)
        {
            _logger.LogInformation($"Adding user: {entity.username}");

            if (request.password != request.password_repeat)
            {
                throw new Exception("password and password_repeat have to be the same");
            }

            entity.password_salt = GenerateSalt();
            entity.password_hash = GenerateHash(entity.password_salt, request.password);
            base.BeforeInsert(request, entity);
        }
        public static string GenerateSalt()
        {
            var byteArray = RNGCryptoServiceProvider.GetBytes(16);


            return Convert.ToBase64String(byteArray);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public Users Login(string username, string password)
        {
            var entity = Context.Users.FirstOrDefault(x => x.username == username);

            if (entity == null)
            {
                return null;
            }

            var hash = GenerateHash(entity.password_salt, password);

            if (hash != entity.password_hash)
            {
                return null;
            }

            return this.Mapper.Map<Users>(entity);
        }
    }
}
