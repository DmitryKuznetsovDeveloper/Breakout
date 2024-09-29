using UI.View;
using UnityEngine;
using Zenject;

namespace UI
{
    public sealed class GameTimerMediator : IInitializable, ITickable
    {
        public TimerView TimerView { get; }

        public readonly float DelayStartGame = 9f;
        private float _currentTime;

        public GameTimerMediator(TimerView timerView) => TimerView = timerView;

        public void Initialize() => _currentTime = DelayStartGame;

        void ITickable.Tick()
        {
            if (_currentTime > 0)
            {
                _currentTime -= Time.deltaTime;
                TimerView.SetTimerLabel(_currentTime);
            }
        }
    }
}