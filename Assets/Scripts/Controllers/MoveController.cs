using System;
using Data;
using SampleGame;
using UnityEngine;

namespace Controllers
{
    public sealed class MoveController : IGameTickable
    {
        private readonly MoveUserInputData _moveUserInputData;
        private readonly Transform _characterTransform;
        private readonly int _restrictMovement;
        private readonly float _speed;

        public MoveController(
            MoveUserInputData moveUserInputData,
            Transform transform, 
            float speed, 
            int restrictMovement)
        {
            _moveUserInputData = moveUserInputData;
            _characterTransform = transform;
            _speed = speed;
            _restrictMovement = restrictMovement;
        }

        public void Tick(float deltaTime)
        {
            var directionX = new Vector3( _moveUserInputData.MoveInputData.x, 0f, 0f) * (_speed * Time.deltaTime);
            if (!directionX.Equals(Vector3.zero))
            {
                var position = _characterTransform.position;
                position.x = Mathf.Clamp(position.x, -_restrictMovement, _restrictMovement);
                position += directionX;
                _characterTransform.transform.position = position;
            }
        }
    }
}