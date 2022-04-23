using System.Collections.Generic;

public abstract class ModelChange
{
    public abstract void Apply(IModelChangeReceiver receiver);

    public class SoundPacks : ModelChange
    {
        public List<SoundPack> Packs;
        public override void Apply(IModelChangeReceiver receiver) => receiver.ApplyChange(this);
    }
}