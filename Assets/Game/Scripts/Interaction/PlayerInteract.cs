using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform _usePointer;
    [Zenject.Inject(Id = "CameraTransform")] private Transform _playerCam;

    [Header("Interaction Settings")]
    [SerializeField] private float _capsuleCastRadius = 1f;
    [SerializeField] private float _capsuleCastLength = 2f;
    [SerializeField] private bool _debugGizmos = true;
    [Zenject.Inject]
    private PlayerInputAction _inputAction;

    private void Awake()
    {
        _inputAction.Player.Interact.performed += ctx => Interact();
    }


    private void Update()
    {
        LookForInteraction();
    }
    private void OnEnable() => _inputAction.Enable();
    private void OnDisable() => _inputAction.Disable();

    public T GetInteraction<T>() where T : Component
    {
        
        List<T> interactables = Interaction.SphereCastFindAll<T>(_playerCam, _capsuleCastRadius, _capsuleCastLength);

        T closest = Interaction.FindClosestToTransform(interactables, _usePointer);

        return closest;
    }


    private void LookForInteraction()
    {
        Interact closest = GetInteraction<Interact>();

        if (closest != null)
        {
            //Debug.Log($"Looking at interactable: {closest.name}");
        }
    }

    private void Interact()
    {
        Debug.Log("Hey");
        Interact closest = GetInteraction<Interact>();
        

        if (closest != null)
        {
            Debug.Log("Interacting with: " + closest.name);
            closest.OnInteract(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        if (!_debugGizmos || _playerCam == null) return;

        Gizmos.color = Color.blue;

        Vector3 capsuleEnd = Vector3.forward * _capsuleCastLength;

        Gizmos.matrix = Matrix4x4.TRS(_playerCam.position, _playerCam.rotation, _playerCam.lossyScale);

        // Draw capsule collider approximation
        Gizmos.DrawWireSphere(capsuleEnd, _capsuleCastRadius);
        Gizmos.DrawLine(Vector3.left * _capsuleCastRadius, capsuleEnd + Vector3.left * _capsuleCastRadius);
        Gizmos.DrawLine(Vector3.right * _capsuleCastRadius, capsuleEnd + Vector3.right * _capsuleCastRadius);
        Gizmos.DrawLine(Vector3.up * _capsuleCastRadius, capsuleEnd + Vector3.up * _capsuleCastRadius);
        Gizmos.DrawLine(Vector3.down * _capsuleCastRadius, capsuleEnd + Vector3.down * _capsuleCastRadius);

        Gizmos.matrix = Matrix4x4.identity;

        if (_usePointer != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_usePointer.position, 0.1f);
        }
    }
    
}
