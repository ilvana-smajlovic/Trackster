using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model.Requests;
using Trackster.Model;
using Trackster.Model.SearchObjects;
using Microsoft.VisualStudio.Services.Users;

namespace Trackster.Services
{
    public interface IUserService : ICRUDService<Users, UserSearchObject, UserInsertRequest, UserUpdateRequest>
    {
        public Users Login(string username, string password);
    }
}
