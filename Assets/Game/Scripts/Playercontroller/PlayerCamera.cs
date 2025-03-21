using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private float _xRotation = 0f;
    private float _ySensitivity = 0.2f;
    private float _rotationSpeed = 0.2f;
    private float _maxVerticalAngle = 80f;
    private Vector2 _swipeDelta;
    private PlayerInputAction _inputAction;

    private void Awake()
    {
        _inputAction = new PlayerInputAction();
        _inputAction.Player.TouchSwipe.performed += ctx => ReadSwipe(ctx);
        _inputAction.Player.TouchSwipe.canceled += ctx => NullifySwipe();
    }
    private void Update()
    {
        float mouseX = _swipeDelta.x;
        float mouseY = _swipeDelta.y;

        _xRotation -= (mouseY) * _ySensitivity;
        _xRotation = Mathf.Clamp(_xRotation, -_maxVerticalAngle, _maxVerticalAngle);
        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        float yaw = _swipeDelta.x * _rotationSpeed;
        transform.Rotate(0f, yaw, 0f);

        //Debug.Log(_swipeDelta);
    }
    private void OnEnable() => _inputAction.Enable();
    private void OnDisable() => _inputAction.Disable();

    private void ReadSwipe(InputAction.CallbackContext ctx)
    {
        _swipeDelta = ctx.ReadValue<Vector2>();
    }
    private void NullifySwipe() => _swipeDelta = Vector2.zero;


}