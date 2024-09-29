using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public sealed class GameOverView : MonoBehaviour
    {
        [SerializeField] private Image backgroundImage;
        [SerializeField] private TMP_Text titleLabel;
        [SerializeField] private float durationFade;
        [SerializeField] private Ease ease;
    
        private Sequence _sequenceDeathScreen;

        public void Awake()
        {
            _sequenceDeathScreen = DOTween.Sequence();
            _sequenceDeathScreen.Append(backgroundImage.DOFade(0.2f, durationFade).From(0f));
            _sequenceDeathScreen.Join(titleLabel.rectTransform.DOLocalMoveX(0f, durationFade).From(-50));
            _sequenceDeathScreen.Join(titleLabel.DOFade(1f, durationFade).From(0f));
            _sequenceDeathScreen.SetEase(ease);
            _sequenceDeathScreen.SetAutoKill(false);
            _sequenceDeathScreen.SetUpdate(true);
            _sequenceDeathScreen.Pause();
        }
        
        public async UniTask PlayDeathScreen()
        {
            _sequenceDeathScreen.OnComplete(PauseDeathScreen).Restart();
            await _sequenceDeathScreen.AsyncWaitForCompletion();
        }

        private void PauseDeathScreen() => 
            _sequenceDeathScreen.Pause();

        private void OnDisable() => _sequenceDeathScreen.OnComplete(PauseDeathScreen).Rewind();

        private void OnDestroy() => _sequenceDeathScreen.Kill();
        
    }
}