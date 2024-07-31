using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BackgroundFader : MonoBehaviour
{
    public List<Sprite> backgroundImages;  // List of background images
    public Image backgroundImage;          // The UI Image component
    public float fadeDuration = 1.0f;      // Duration of the fade
    public float displayDuration = 5.0f;   // Duration each image is displayed

    private int currentImageIndex = 0;
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = backgroundImage.GetComponent<CanvasGroup>();
        if (backgroundImages.Count > 0)
        {
            backgroundImage.sprite = backgroundImages[0];
            StartCoroutine(FadeImages());
        }
    }

    IEnumerator FadeImages()
    {
        while (true)
        {
            yield return StartCoroutine(FadeOut());
            currentImageIndex = (currentImageIndex + 1) % backgroundImages.Count;
            backgroundImage.sprite = backgroundImages[currentImageIndex];
            yield return StartCoroutine(FadeIn());
            yield return new WaitForSeconds(displayDuration);
        }
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = 1f - Mathf.Clamp01(elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0f;
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1f;
    }
}
