using System.Collections.Generic;
using System.Linq;
using Configs;

namespace Models
{
    public class User
    {
        public IEnumerable<SoundPackModel> Packs => _packs;
        public IEnumerable<ObstacleModel> Obstacles => _obstacles;
        
        private List<SoundPackModel> _packs = new List<SoundPackModel>();
        private List<ObstacleModel> _obstacles = new List<ObstacleModel>();

        public void Update(ModelChange.ObstaclesChange change)
        {
            _packs.Clear();
            _obstacles = change.Obstacles.Select(CreateModel).ToList();
        }
        
        public void Update(ModelChange.SoundPacks change)
        {
            _obstacles.Clear();
            _packs = change.Packs.Select(CreateModel).ToList();
        }

        private SoundPackModel CreateModel(SoundPack data) => new SoundPackModel { Data = data };
        private ObstacleModel CreateModel(Obstacle data) => new ObstacleModel { Data = data };
    }
}