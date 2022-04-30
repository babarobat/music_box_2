using UnityEngine;
using UserInterface.Windows;

namespace UserInterface
{
    public static class UI
    {
        public static WindowsManager Windows { get; } = new WindowsManager();

        public static void SetRoot(Transform root)
        {
            Windows.SetRoot(root);
        }

    }
}