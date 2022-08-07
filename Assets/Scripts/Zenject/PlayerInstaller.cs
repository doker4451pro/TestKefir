using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private LearningPlayer _player;
    public override void InstallBindings()
    {
        Container.Bind<LearningPlayer>()
            .FromInstance(_player)
            .AsSingle();
    }
}