using UI;
using UI.View;
using Zenject;

namespace Installers
{
    public sealed class UIInstaller : MonoInstaller
    { 
        public override void InstallBindings()
        {
            //View
            Container.Bind<GameOverView>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<TimerView>().FromComponentInHierarchy().AsSingle().NonLazy();
            
            //Mediator
            Container.BindInterfacesTo<GameOverMediator>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameTimerMediator>().AsSingle().NonLazy();
        }
    }
}