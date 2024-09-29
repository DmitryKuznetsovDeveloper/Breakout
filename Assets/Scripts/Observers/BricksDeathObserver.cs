using Components;
using UnityEngine;

namespace Observers
{
    public sealed class BricksDeathObserver : MonoBehaviour
    {
        private HealthComponent _healthComponent;

        private void Awake() => _healthComponent = GetComponent<HealthComponent>();

        private void OnEnable() => _healthComponent.OnDeath += BricksDeath;

        private void OnDisable() => _healthComponent.OnDeath -= BricksDeath;
        private void BricksDeath() => _healthComponent.gameObject.SetActive(false);
    }
}