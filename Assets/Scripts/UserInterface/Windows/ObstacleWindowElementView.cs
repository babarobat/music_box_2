using System;
using Configs.Obstacles;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.Windows
{
    public class ObstacleWindowElementView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private Image _icon;
        [SerializeField] private UIButton _button;
        
        private ObstacleWindowElementContext _context;

        private void Awake()
        {
            _button.OnClick += OnButtonClick;
        }

        public void SetContext(ObstacleWindowElementContext context)
        {
            _context = context;
            
            switch (_context.Data)
            {
                case Cylinder obstacle: UpdateView(obstacle); break;
                case Cube obstacle: UpdateView(obstacle); break;
                case Spawner obstacle: UpdateView(obstacle); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
        
        private void OnButtonClick()
        {
            _context.OnClick?.Invoke(_context.Data);
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
