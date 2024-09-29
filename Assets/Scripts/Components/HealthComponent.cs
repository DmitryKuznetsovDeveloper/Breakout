using System;
using UnityEngine;

namespace Components
{
    public sealed class HealthComponent : MonoBehaviour
    {
        public event Action<int> OnChangeHealth;
        public event Action<int> OnTakeDamage;
        public event Action OnDeath;
        public bool IsAlive() => health > 0;
        public bool IsHealthFull() => health == maxHitPoints;
        public int GetCurrentHitPoints() => health;
        
        [SerializeField, Min(0)] private int maxHitPoints = 100;
        [SerializeField, Min(0)] private int health = 50;
        
        public void TakeDamage(int damage)
        {
            health = Math.Max(0, health - damage);
            if (health <= 0)
            {
                OnDeath?.Invoke();
                Debug.Log($"{gameObject.name} = death");
            }
            else
                OnTakeDamage?.Invoke(damage);
            
            OnChangeHealth?.Invoke(health);
        }

        public void RestoreHitPoints(int healthPoints)
        {
            health = Mathf.Min(health + healthPoints, maxHitPoints);
            OnChangeHealth?.Invoke(healthPoints);
        }
    }
}