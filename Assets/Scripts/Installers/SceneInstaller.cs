using Configs;
using ObjectPool;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private BrickGridConfig brickGridConfig;
        [SerializeField] private BricksPool bricksPool;
        
        public override void InstallBindings()
        {
            Container.Bind<BrickGridConfig>().FromInstance(brickGridConfig).NonLazy();
            Container.BindInterfacesTo<BricksPool>().FromInstance(bricksPool).AsSingle().NonLazy();
        }
    }
}