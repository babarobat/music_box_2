using UnityEngine;

namespace Windows
{
    public interface IWindow
    {
        GameObject GameObject { get; }
        void Close();
    }
}