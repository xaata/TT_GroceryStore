using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Camera _playerCamera;
    public override void InstallBindings()
    {
        PlayerInputAction inputActions = new PlayerInputAction();
        //inputActions.Enable();
        
        Container.Bind<Camera>().FromInstance(_playerCamera).AsSingle();
        Container.Bind<Transform>().WithId("CameraTransform").FromInstance(_playerCamera.transform).AsSingle();
        //----------���������� �������----------
        Container.Bind<PlayerInputAction>().FromInstance(inputActions).AsSingle().NonLazy();
        Container.Bind<PlayerMovement>().FromInstance(_player.GetComponent<PlayerMovement>()).AsSingle(); 
        Container.Bind<PlayerCamera>().FromInstance(_player.GetComponent<PlayerCamera>()).AsSingle();   
        Container.Bind<PlayerInteract>().FromInstance(_player.GetComponent<PlayerInteract>()).AsSingle();
        Container.Bind<CharacterController>().FromInstance(_player.GetComponent<CharacterController>()).AsSingle();
        // ����� ��� - �� ������������ FromComponentInHierarchy ������ FromInstance, 
        // ��� ��� ����� �� �������� ���������� � Awake ���� 1 ��� � ��� ������ ���������� ����������� � ����,
        // ���� ������ � ���, ��� ������� ��� �������� ������ � ����?
    }
}
