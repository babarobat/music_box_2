using System.Collections.Generic;
using System.Linq;

public class User
{
    public IEnumerable<SoundPackModel> Packs => _packs;
    public List<SoundPackModel> _packs = new List<SoundPackModel>();

    public void Update(ModelChange.SoundPacks change)
    {
        _packs.Clear();
        _packs = change.Packs.Select(CreateModel).ToList();
    }

    private SoundPackModel CreateModel(SoundPack data) => new SoundPackModel { Data = data };
}