using System.Linq;
using UnityEngine;

public class WindowsManager
{
    private IWindow _opened;
    private Transform _root;
    private Lybrary _library;

    private readonly WindowBinder _binder = new WindowBinder();

    public void SetLibrary(Lybrary library)
    {
        _library = library;
    }
    
    public void SetRoot( Transform root)
    {
        _root = root;
    }
    public TWindow Open<TWindow, TWindowData>(TWindowData data)
        where TWindow: WindowBase<TWindow, TWindowData>
    {
        if (_opened is TWindow opened)
        {
            return opened;
        }

        var prefab = _library.AllWindows.First(x => x is TWindow) as TWindow;
        var window = Object.Instantiate(prefab, _root);

        _opened?.Close();
        
        window.Apply(_binder, data);

        window.gameObject.SetActive(true);
        _opened = window;

        return window;
    }
    
    public void Close(IWindow window)
    {
        if (_opened == window)
        {
            _opened.GameObject.SetActive(false);
            _opened = null;
        }
    }
}