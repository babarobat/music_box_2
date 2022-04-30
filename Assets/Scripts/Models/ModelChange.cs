using System.Collections.Generic;
using Configs;

namespace Models
{
    public abstract class ModelChange
    {
        public abstract void Apply(IModelChangeReceiver receiver);

        public class SoundPacks : ModelChange
        {
            public IEnumerable<SoundPack> Packs;
            public override void Apply(IModelChangeReceiver receiver) => receiver.ApplyChange(this);
        }

        public class ObstaclesChange : ModelChange
        {
            public IEnumerable<Obstacle> Obstacles;
            public override void Apply(IModelChangeReceiver receiver) => receiver.ApplyChange(this);
        }
    }
}