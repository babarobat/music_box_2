using UnityEngine;

namespace UserInterface.Windows
{
    public interface IWindow
    {
        GameObject GameObject { get; }
        void Close();
    }
}