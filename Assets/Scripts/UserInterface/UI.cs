using System;
using UnityEngine;
using UserInterface.Windows;

namespace UserInterface
{
    [Obsolete("should be refactored from static to service")]
    public static class UI
    {
        public static WindowsManager Windows { get; } = new();

        public static void SetRoot(Transform root)
        {
            Windows.SetRoot(root);
        }

    }
}