using UnityEngine;

namespace Components
{
    public sealed class DealDamageAction : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private AudioSource audioSource;

        public void OnTriggerEnter(Collider other) =>
            DealDamage(other, damage);

        private void OnCollisionEnter(Collision other) => 
            DealDamage(other, damage);

        private void DealDamage(Collider collider, int damage)
        {
            if (collider.TryGetComponent(out HealthComponent healthComponent))
            {
                audioSource.Play();
                healthComponent.TakeDamage(damage);
            }
        }
        
        private void DealDamage(Collision collision, int damage)
        {
            if (collision.gameObject.TryGetComponent(out HealthComponent healthComponent))
            {
                audioSource.Play();
                healthComponent.TakeDamage(damage);
            }
        }
    }
}