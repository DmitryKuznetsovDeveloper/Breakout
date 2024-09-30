using Controllers;
using Game;
using SampleGame;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = "GameInstaller", menuName = "Installers/GameInstaller", order = 0)]
    public class GameCoreInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameManager>().AsSingle().NonLazy();
            Container.Bind<GameLauncher>().AsCached().NonLazy();
            Container.Bind<ApplicationExiter>().AsCached().NonLazy();
            Container.BindInterfacesTo<GameController>().AsCached().NonLazy();
        }
    }
}