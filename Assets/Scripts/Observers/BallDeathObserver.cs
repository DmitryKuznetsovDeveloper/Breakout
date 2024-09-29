using Components;
using SampleGame;
using Zenject;

namespace Observers
{
    public sealed class BallDeathObserver : IInitializable, IGameFinishListener
    {
        private readonly HealthComponent _healthComponent;
        private readonly GameManager _gameManager;

        public BallDeathObserver(
            HealthComponent healthComponent,
            GameManager gameManager)
        {
            _healthComponent = healthComponent;
            _gameManager = gameManager;
        }
         void IInitializable.Initialize() => _healthComponent.OnDeath += BallDeath;

         void IGameFinishListener.OnFinishGame() => _healthComponent.OnDeath -= BallDeath;

         public void BallDeath() => _gameManager.FinishGame();
    }
}