using UnityEngine;
using Zenject;

public class MovementInstaller : MonoInstaller
{
    [SerializeField] private FixedJoystick _fixedJoystick;
    public override void InstallBindings()
    {
        Container.Bind<FixedJoystick>().FromInstance(_fixedJoystick).AsSingle();
    }
}