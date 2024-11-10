using EasyNetQ;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackster.Model;
using Trackster.Model.Messages;
using Trackster.Model.Requests;
using Trackster.Repository;

namespace Trackster.Services.MediaStateMachine
{
    public class DraftMediaState : BaseMediaState
    {
        public DraftMediaState(TracksterContext context, IMapper mapper, IServiceProvider serviceProvider) : base(context, mapper, serviceProvider)
        {
        }

        public override Media Update(int id, MediaUpdateRequest request)
        {
            var set = Context.Set<Media>();

            var entity = set.Find(id);

            Mapper.Map(request, entity);

            Context.SaveChanges();

            return Mapper.Map<Media>(entity);
        }

        public override Media Activate(int id)
        {
            var set = Context.Set<Media>();

            var entity = set.Find(id);

            entity.state_machine = "active";

            Context.SaveChanges();

            var bus = RabbitHutch.CreateBus("host=localhost:5673");

            var mappedEntity = Mapper.Map<Media>(entity);
            MediaActivated message = new MediaActivated { media = mappedEntity };
            bus.PubSub.Publish(message);

            return mappedEntity;
        }

        public override Media Hide(int id)
        {
            var set = Context.Set<Media>();

            var entity = set.Find(id);

            entity.state_machine = "hidden";

            Context.SaveChanges();

            return Mapper.Map<Media>(entity);
        }

        public override List<string> AllowedActions(Media entity)
        {
            return new List<string>() { nameof(Activate), nameof(Update), nameof(Hide) };
        }
    }
}
