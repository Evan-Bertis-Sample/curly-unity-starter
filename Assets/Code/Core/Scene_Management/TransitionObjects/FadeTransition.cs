using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Core.SceneManagement.Transitions
{
    [CreateAssetMenu(fileName = "FadeTransition", menuName = "Curly/Scene Transitions/Fade Transition")]
    public class FadeTransition : ScreenTransitionObject
    {
        public Color color = Color.black;
        [Range(0, 1)] public float startingOpacity = 0;
        [Range(0, 1)] public float endingOpacity = 1;
        public float fadeDuration = 1f;

        private Image _fadeImage;
        private Tweener _fadeTween;

        public override void PrepareAnimation(Canvas screenCanvas)
        {
            GameObject fadeObject = new GameObject("FadeObject");
            fadeObject.transform.SetParent(screenCanvas.transform, false);

            _fadeImage = fadeObject.AddComponent<Image>();
            _fadeImage.color = new Color(color.r, color.g, color.b, startingOpacity);
            _fadeImage.rectTransform.anchoredPosition = Vector2.zero;
            _fadeImage.rectTransform.sizeDelta = new Vector2(screenCanvas.pixelRect.width, screenCanvas.pixelRect.height);
            _fadeImage.rectTransform.anchorMin = Vector2.zero;
            _fadeImage.rectTransform.anchorMax = Vector2.one;
        }

        public override async Task Transition(Canvas screenCanvas)
        {
            _fadeTween = _fadeImage.DOFade(endingOpacity, fadeDuration);
            await _fadeTween.AsyncWaitForCompletion();
        }

        public override void EndAnimation(Canvas screenCanvas)
        {
            _fadeTween?.Kill();
            if (_fadeImage != null)
            {
                Destroy(_fadeImage.gameObject);
                _fadeImage = null;
            }
        }
    }
}
