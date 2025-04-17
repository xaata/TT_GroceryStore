using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [Zenject.Inject] private Camera _camera;

    private float _xRotation = 0f;
    private float _sensitivity = 0.2f;
    private float _rotationSpeed = 0.2f;
    private float _maxVerticalAngle = 80f;
    private Vector2 _swipeDelta;
    [Zenject.Inject]
    private PlayerInputAction _inputAction;
    private float _yRotation = 0f;

    private void Awake()
    {
        _inputAction.Player.TouchSwipe.performed += ctx => ReadSwipe(ctx);
        _inputAction.Player.TouchSwipe.canceled += ctx => NullifySwipe();
    }
    private void OnEnable() => _inputAction.Enable();
    private void OnDisable() => _inputAction.Disable();

    private void ReadSwipe(InputAction.CallbackContext ctx)
    {
        Vector2 swipeDelta = ctx.ReadValue<Vector2>();

        // Если входное значение корректное, обновляем углы
        if (!float.IsNaN(swipeDelta.x) && !float.IsNaN(swipeDelta.y))
        {
            _xRotation -= swipeDelta.y * _sensitivity;
            _yRotation += swipeDelta.x * _sensitivity;

            // Ограничиваем вертикальный угол
            _xRotation = Mathf.Clamp(_xRotation, -_maxVerticalAngle, _maxVerticalAngle);

            // Прямое задание углов поворота
            _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);
        }
    }
    private void NullifySwipe() => _swipeDelta = Vector2.zero;
}