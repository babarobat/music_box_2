using System;
using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Windows
{
    public class ObstacleWindowElementView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private Image _icon;

        private ObstacleWindowElementContext _context;
        public void SetContext(ObstacleWindowElementContext context)
        {
            _context = context;
            
            switch (_context.Model.Data)
            {
                case Cylinder cylinder: UpdateView(cylinder); break;
                case Cube cylinder: UpdateView(cylinder); break;
                case Spawner cylinder: UpdateView(cylinder); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateView(Cylinder data)
        {
            _name.text = data.Visual.Name;
            _icon.sprite = data.Icon;
        }
        
        private void UpdateView(Cube data)
        {
            _name.text = data.Visual.Name;
            _icon.sprite = data.Icon;
        }
        
        private void UpdateView(Spawner data)
        {
            _name.text = data.Visual.Name;
            _icon.sprite = data.Icon;
        }
    }
}