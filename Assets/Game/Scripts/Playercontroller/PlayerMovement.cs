using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private Transform _cameraTransform;

    private CharacterController _characterController;
    private PlayerInputAction _inputAction;
    private Vector2 _moveInput;
    private Vector3 _velocity;  

    private void Awake()
    {
        _inputAction = new PlayerInputAction();
        _characterController = GetComponent<CharacterController>();

        _inputAction.Player.Move.performed += ctx => _moveInput = ctx.ReadValue<Vector2>();
        _inputAction.Player.Move.canceled += ctx => _moveInput = Vector2.zero;
    }

    private void OnEnable() => _inputAction.Enable();
    private void OnDisable() => _inputAction.Disable();

    private void Update()
    {
        ApplyGravity();
        Move();
        RotateWithCamera();
    }
    private void Move()
    {
        Vector3 moveDirection = new Vector3(_moveInput.x, 0, _moveInput.y);
        moveDirection = _cameraTransform.TransformDirection(moveDirection);
        moveDirection.y = 0;
        moveDirection.Normalize();
        _characterController.Move(moveDirection * _moveSpeed * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (_characterController.isGrounded && _velocity.y < 0)
            _velocity.y = -2f;

        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }
    private void RotateWithCamera()
    {
        transform.rotation = Quaternion.Euler(0, _cameraTransform.eulerAngles.y, 0);
    }
}
