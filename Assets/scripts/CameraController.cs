using UnityEngine;

public class CameraController : MonoBehaviour
{
    private InputSystem _input;

    private void Awake()
    {
        _input = Services.Get<InputSystem>();
    }
    private void Update()
    {
        if (_input.HasTouches)
        {
            var touch = _input.Touches[0];

            Debug.Log($"[{GetType()}]: {touch.position}");
        }
    }
}