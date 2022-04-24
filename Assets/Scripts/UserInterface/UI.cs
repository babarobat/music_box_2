using Windows;
using Configs;
using UnityEngine;

namespace UserInterface
{
    public static class UI
    {
        public static WindowsManager Windows { get; } = new WindowsManager();

        public static void SetLibrary(Lybrary library)
        {
            Windows.SetLibrary(library);
        }
    
        public static void SetRoot(Transform root)
        {
            Windows.SetRoot(root);
        }

    }
}