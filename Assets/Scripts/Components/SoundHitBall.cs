using Installers;
using UnityEngine;

namespace Components
{
    public class SoundHitBall : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        private void OnCollisionEnter(Collision other) => PlaySound(other, audioSource);
        
        
        private void PlaySound(Collision collision, AudioSource audio)
        {
            if (collision.gameObject.TryGetComponent(out BallInstaller ballInstaller)) 
                audio.Play();
        }
    }
}