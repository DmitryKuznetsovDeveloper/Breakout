using Components;
using Controllers;
using Data;
using Input;
using Observers;
using UnityEngine;
using Zenject;

namespace Installers
{
    public sealed class BallInstaller : MonoInstaller
    {
        [SerializeField] private Transform startPosition;
        public override void InstallBindings()
        {
            //Data
            Container.Bind<JumpUserInputData>().AsCached().NonLazy();
            
            //Input
            Container.BindInterfacesTo<JumpUserInputSystem>().AsSingle().NonLazy();
            
            //Controller
            Container.BindInterfacesAndSelfTo<BallJumpController>().AsSingle().WithArguments(startPosition).NonLazy();
            
            //Components
            Container.Bind<Rigidbody>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<HealthComponent>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<JumpComponent>().FromComponentInHierarchy().AsSingle().NonLazy();
            
            //Observer
            Container.BindInterfacesTo<BallDeathObserver>().AsSingle().NonLazy();
        }
    }
}