﻿using Configs;
using Cysharp.Threading.Tasks;
using Model;
using UnityEngine;
using Zenject;

namespace ObjectPool
{
    public sealed class BricksPool : MonoBehaviour
    {
        [SerializeField] private bool autoExpand;
        [SerializeField] private BrickView brickPrefab;
        private BrickGridConfig _brickGridConfig;

        [Inject]
        public void Construct(BrickGridConfig brickGridConfig) => _brickGridConfig = brickGridConfig;

        private readonly float _startPositionX = -9f;
        private readonly float _startPositionY = 8.6f;
        private readonly float _startPositionZ = 0f;
        private readonly float _offsetX = 4.5f;
        private readonly float _offsetY = -1.6f;

        private int _poolCount;
        private PoolMono<BrickView> _poolMono;

        private void Awake()
        {
            _poolMono = new PoolMono<BrickView>(brickPrefab, _poolCount, transform);
            _poolMono.autoExpand = autoExpand;
            CreateBrickGrid();
        }
        
        //Задержка чтобы кирпичи нормально появлялись =)
        private async void Start()
        {
            await UniTask.WaitForSeconds(2, cancellationToken: this.GetCancellationTokenOnDestroy());
            await ShowBrick();
        }

        private void CreateBrickGrid()
        {
            var position = new Vector3(_startPositionX, _startPositionY, _startPositionZ);
            for (int i = 0; i < _brickGridConfig.colums.Length; i++)
            {
                for (int j = 0; j < _brickGridConfig.colums[i].rows.Length; j++)
                {
                    var brick = _poolMono.GetFreeElement(true);
                    brick.SetColor(_brickGridConfig.colums[i].rows[j].rowColor);
                    brick.transform.localPosition = position;
                    position.y += _offsetY;
                }
                position.x += _offsetX;
                position.y = _startPositionY;
            }
        }

        private async UniTask ShowBrick()
        {
            foreach (var brick in _poolMono.Pool) 
                await brick.ShowBrick();
        }
    }
}