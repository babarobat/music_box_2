using UnityEngine;

namespace UserInterface
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private Transform _windowsRoot;
        private void Awake()
        {
            UI.SetRoot(_windowsRoot);
        }
    }
}