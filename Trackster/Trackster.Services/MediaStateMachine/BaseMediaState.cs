using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model;
using Trackster.Model.Requests;
using Trackster.Repository;

namespace Trackster.Services.MediaStateMachine
{
    public class BaseMediaState
    {
        public TracksterContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public IServiceProvider ServiceProvider { get; set; }

        public BaseMediaState(TracksterContext context, IMapper mapper, IServiceProvider serviceProvider)
        {
            Context = context;
            Mapper = mapper;
            ServiceProvider = serviceProvider;
        }
        public virtual Media Insert(MediaInsertRequest request)
        {
            throw new Model.UserException("Metoda nije dozvoljena");
        }

        public virtual Media Update(int id, MediaUpdateRequest request)
        {
            throw new Model.UserException("Metoda nije dozvoljena");
        }

        public virtual Media Activate(int id)
        {
            throw new Model.UserException("Metoda nije dozvoljena");
        }

        public virtual Media Hide(int id)
        {
            throw new Model.UserException("Metoda nije dozvoljena");
        }

        public virtual Media Edit(int id)
        {
            throw new Model.UserException("Metoda nije dozvoljena");
        }

        public virtual List<string> AllowedActions(Media entity)
        {
            throw new Model.UserException("Metoda nije dozvoljena");
        }


        public BaseMediaState CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                    return ServiceProvider.GetService<InitialMediaState>();
                case "draft":
                    return ServiceProvider.GetService<DraftMediaState>();
                case "active":
                    return ServiceProvider.GetService<ActiveMediaState>();
                case "hidden":
                    return ServiceProvider.GetService<HiddenMediaState>();
                default: throw new Exception("State not recognized");
            }
        }
    }

}
