using Cysharp.Threading.Tasks;
using SampleGame;
using UI;
using Zenject;

namespace Controllers
{
    public sealed class GameController : IInitializable
    {
        private readonly GameManager _gameManager;
        private readonly GameTimerMediator _gameTimerMediator;

        public GameController(GameManager gameManager, GameTimerMediator gameTimerMediator)
        {
            _gameManager = gameManager;
            _gameTimerMediator = gameTimerMediator;
        }

        async void IInitializable.Initialize()
        {
             _gameTimerMediator.TimerView.ShowGameStartScreen();
            await UniTask.WaitForSeconds(_gameTimerMediator.DelayStartGame);
            await _gameTimerMediator.TimerView.HideScreenStart();
            _gameManager.StartGame();
        }
    }
}