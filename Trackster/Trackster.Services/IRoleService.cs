﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model.Requests;
using Trackster.Model.SearchObjects;
using Trackster.Model;

namespace Trackster.Services
{
    public interface IRoleService : ICRUDService<Roles, NameSearchObject, RoleInsertRequest, RoleUpdateRequest>
    {

    }
}
