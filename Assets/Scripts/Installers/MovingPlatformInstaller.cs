using Controllers;
using Data;
using Input;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class MovingPlatformInstaller : MonoInstaller
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private int restrictMovement;
        public override void InstallBindings()
        {
            //Data
            Container.Bind<MoveUserInputData>().AsCached().NonLazy();
            
            //Input
            Container.BindInterfacesTo<MoveUserInputSystem>().AsSingle().NonLazy();
            
            //Controller
            Container.BindInterfacesAndSelfTo<MoveController>().AsSingle().WithArguments(transform,moveSpeed,restrictMovement).NonLazy();
        }
    }
}