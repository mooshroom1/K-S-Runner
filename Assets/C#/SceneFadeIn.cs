using UnityEngine;
using UnityEngine.UI;

public class SceneFadeIn : MonoBehaviour
{
    public CanvasGroup canvasGroup; // Ссылка на Canvas Group
    public float fadeDuration = 2.0f; // Длительность появления

    private void Start()
    {
        // Убедимся, что начальная прозрачность 1
        Time.timeScale = 1f;
        canvasGroup.alpha = 1f;
        StartCoroutine(FadeIn());
    }

    private System.Collections.IEnumerator FadeIn()
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = 1 - (timer / fadeDuration); // Уменьшаем альфа-канал
            yield return null;
        }

        canvasGroup.alpha = 0f; // Убедимся, что полностью прозрачно
        canvasGroup.interactable = false; // Отключаем взаимодействие
        DestroyObject(gameObject);
    }
}

