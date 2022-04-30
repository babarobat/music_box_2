using System.Collections.Generic;
using Models;
using TMPro;
using UnityEngine;
using UserInterface;

namespace Windows
{
    public class ObstaclesWindow : WindowBase<ObstaclesWindow, ObstaclesWindowData>
    {
        [SerializeField] private RectTransform _contentContainer;
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private ObstacleWindowElementView _prefab;
        [SerializeField] private UIButton _closeButton;

        private ObstaclesWindowViewModel _viewModel;

        private readonly List<ObstacleWindowElementView> _elements = new List<ObstacleWindowElementView>();

        private void Awake()
        {
            _closeButton.OnClick += OnCloseClick;
        }

        public void Bind(ObstaclesWindowViewModel viewModel)
        {
            _viewModel = viewModel;
            
            viewModel.Title.OnChanged += OnTitleChanged;
            viewModel.OnObstaclesChanged += OnObstaclesChanged;
            
            OnTitleChanged();
            OnObstaclesChanged();
        }

        private void OnTitleChanged()
        {
            _title.text = _viewModel.Title.Value;
        }
        
        private void OnObstaclesChanged()
        {
            ClearElements();
            CreateElements();
        }
        
        private void OnCloseClick()
        {
            Close();
        }
        
        private void CreateElements()
        {
            foreach (var obstacleModel in _viewModel.Obstacles)
            {
                CreateAndRegisterElement(obstacleModel);
            }
        }

        private void CreateAndRegisterElement(ObstacleModel obstacleModel)
        {
            var obstacleWindowElementView = Instantiate(_prefab, _contentContainer);
            obstacleWindowElementView.SetContext(new ObstacleWindowElementContext
            {
                Model = obstacleModel, 
                OnClick = _viewModel.HandleClick,
            });

            _elements.Add(obstacleWindowElementView);
        }
        
        private void ClearElements()
        {
            foreach (var element in _elements)
            {
                Destroy(element.gameObject);
            }

            _elements.Clear();
        }

        private void OnDestroy()
        {
            _closeButton.OnClick -= OnCloseClick;
            _viewModel.Title.OnChanged -= OnTitleChanged;
            _viewModel.OnObstaclesChanged -= OnObstaclesChanged;
        }
    }
}