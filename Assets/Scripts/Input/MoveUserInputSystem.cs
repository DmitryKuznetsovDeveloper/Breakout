using System;
using Data;
using SampleGame;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Input
{
    public sealed class MoveUserInputSystem : IInitializable,IGameTickable, IDisposable
    {
        private InputAction _moveActon;
        private float2 _moveInput;

        private readonly MoveUserInputData _inputData;
        public MoveUserInputSystem(MoveUserInputData inputData) => _inputData = inputData;

        void IInitializable.Initialize()
        {
            _moveActon = new InputAction("move", binding: "<Gamepad>/LeftStick");
            _moveActon.AddCompositeBinding("Dpad")
                .With("Left", "<Gamepad>/Dpad/left")
                .With("Right", "<Gamepad>/Dpad/right")
                .With("Left", "<Keyboard>/a")
                .With("Right", "<Keyboard>/d")
                .With("Left", "<Keyboard>/leftArrow")
                .With("Right", "<Keyboard>/rightArrow");

            _moveActon.started += context => { _moveInput = context.ReadValue<Vector2>(); };
            _moveActon.performed += context => { _moveInput = context.ReadValue<Vector2>(); };
            _moveActon.canceled += context => { _moveInput = context.ReadValue<Vector2>(); };
            _moveActon.Enable();
        }

        void IGameTickable.Tick(float deltaTime) =>
            _inputData.MoveInputData = _moveInput;

        void IDisposable.Dispose() =>
            _moveActon?.Dispose();
    }
}