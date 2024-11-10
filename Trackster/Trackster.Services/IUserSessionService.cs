using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;

namespace Trackster.Services
{
    public interface IUserSessionService : ICRUDService<UserSessions, UserSessionSearchObject, UserSessionInsertRequest, UserSessionUpdateRequest>
    {

    }
}
