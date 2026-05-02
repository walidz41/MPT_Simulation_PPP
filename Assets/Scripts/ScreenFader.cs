using System.Threading.Tasks;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    public static ScreenFader instance;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float fadeDuration = 1f;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    async Task Fade(float targetTransparency)
    {
        float start = canvasGroup.alpha;
        float t = 0; // Fixed the double semicolon

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            // The math is correct here!
            canvasGroup.alpha = Mathf.Lerp(start, targetTransparency, t / fadeDuration);
            await Task.Yield();
        }
        canvasGroup.alpha = targetTransparency;
    }

    public async Task FadeOut()
    {
        await Fade(1f);
    }

    public async Task FadeIn()
    {
        await Fade(0f);
    }
}
