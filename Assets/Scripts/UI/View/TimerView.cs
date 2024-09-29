using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI.View
{
    public sealed class TimerView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup allCanvasGroups;
        [SerializeField] private TMP_Text timer;
        [SerializeField] private float durationFade;
        [SerializeField] private float durationScale;
        [SerializeField] private float scaleFactor;
        [SerializeField] private Ease easeScale;

        private Sequence _sequenceShowTimerScreen;
        private Tween _hideTimerScreen;
        private Tween _scaleTimer;

        private void Awake()
        {
            _sequenceShowTimerScreen = DOTween.Sequence();
            _sequenceShowTimerScreen.Append(allCanvasGroups.DOFade(1f, durationFade).From(0f));
            _sequenceShowTimerScreen.Join(timer.DOFade(1f, durationFade).From(0f));
            _sequenceShowTimerScreen.SetUpdate(true);
            _sequenceShowTimerScreen.SetAutoKill(false);
            _sequenceShowTimerScreen.Pause();

            _scaleTimer = timer.rectTransform.DOScale(scaleFactor, durationScale).SetLoops(-1, LoopType.Yoyo)
                .SetEase(easeScale);
            _scaleTimer.SetUpdate(true);
            _scaleTimer.SetAutoKill(false);
            _scaleTimer.Pause();

            _hideTimerScreen = allCanvasGroups.DOFade(0f, durationFade);
            _hideTimerScreen.SetUpdate(true);
            _hideTimerScreen.SetAutoKill(false);
            _hideTimerScreen.Pause();
        }

        public void ShowGameStartScreen()
        {
            ShowSequenceTimer();
            _scaleTimer.Restart();
        }

        public async UniTask HideScreenStart()
        {
            _scaleTimer.Pause();
            _hideTimerScreen.OnComplete(PauseHideScreenStart).Restart();
            await _hideTimerScreen.AsyncWaitForCompletion();
        }

        public void SetTimerLabel(float seconds) => timer.text = $"{seconds:0}";

        private void ShowSequenceTimer() => _sequenceShowTimerScreen.OnComplete(PauseSequenceTimer).Restart();

        private void PauseSequenceTimer() => _sequenceShowTimerScreen.Pause();

        private void PauseHideScreenStart() => _hideTimerScreen.Pause();

        private void PauseScaleTimer() => _scaleTimer.Pause();

        private void OnDisable()
        {
            _sequenceShowTimerScreen.OnComplete(PauseSequenceTimer).Rewind();
            _scaleTimer.OnComplete(PauseScaleTimer).Rewind();
            PauseHideScreenStart();
        }

        private void OnDestroy()
        {
            _hideTimerScreen.Kill();
            _sequenceShowTimerScreen.Kill();
            _scaleTimer.Kill();
        }
    }
}