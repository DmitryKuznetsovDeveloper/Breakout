using Components;
using Data;
using SampleGame;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public sealed class BallJumpController : IGameStartListener,IGameTickable
    {
        private JumpUserInputData _jumpUserInputData;
        private JumpComponent _jumpComponent;
        private Transform _startPosition;
        private int _countJump;

        [Inject]
        public void Construct(JumpUserInputData jumpUserInputData,
            JumpComponent jumpComponent,
            Transform startPosition)
        {
            _jumpUserInputData = jumpUserInputData;
            _jumpComponent = jumpComponent;
            _startPosition = startPosition;
        }

        public void OnStartGame() => _countJump = -1;
        public void Tick(float deltaTime)
        {
            if (_jumpUserInputData.IsJumpInputData && _countJump < 0)
            {
                _jumpComponent.Jump();
                _countJump++;
            }
            else if(_countJump < 0)
                _jumpComponent.transform.position = _startPosition.position;
        }

    }
}