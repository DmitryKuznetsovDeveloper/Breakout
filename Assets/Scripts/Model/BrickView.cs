using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Model
{
    public class BrickView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Vector3 endScale;
        [SerializeField] private float duration;
        [SerializeField] private Ease ease;
        

        private Tween _tweenBrickShow;

        public void Awake()
        {
            _tweenBrickShow = transform.DOScale(endScale, duration).From(0f);
            _tweenBrickShow.SetEase(ease);
            _tweenBrickShow.SetUpdate(true);
            _tweenBrickShow.SetAutoKill(false);
            _tweenBrickShow.Pause();
        }

        public void SetColor(Color color) => meshRenderer.material.color = color;
        
        public async UniTask ShowBrick()
        {
            _tweenBrickShow.OnComplete(PauseBrickShow).Restart();
            audioSource.Play();
            await _tweenBrickShow.AsyncWaitForCompletion();
        }
        
        private void PauseBrickShow() =>
            _tweenBrickShow.Pause();

        private void OnDisable()
        {
            _tweenBrickShow.Rewind();
            PauseBrickShow();
        }

        private void OnDestroy() => _tweenBrickShow.Kill();
        
    }
}