using Models;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace Infrastructure.Services.Models
{
    public class ModelService : IModelService
    {
        private const string MODEL_KEY = "model";
        public Model Model { get; private set; }

        public void Init()
        {
            var json = PlayerPrefs.GetString(MODEL_KEY);
            if (string.IsNullOrEmpty(json))
            {
                Model = new Model();
                return;
            }

            Model = JsonConvert.DeserializeObject<Model>(json);
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(Model);
            PlayerPrefs.SetString(MODEL_KEY, json);
            PlayerPrefs.Save();
        }
    }
}