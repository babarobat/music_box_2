using UnityEngine;

namespace Infrastructure.Services.UI
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private Transform _windowsRoot;
        [SerializeField] private Transform _hudRoot;
        public Transform WindowsRoot => _windowsRoot;
        public Transform HudRoot => _hudRoot;
    }
}