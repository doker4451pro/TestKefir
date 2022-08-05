using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private UIInteract _uiInteract;
    public override void InstallBindings()
    {
        Container.Bind<UIInteract>()
            .FromInstance(_uiInteract)
            .AsSingle();
    }
}