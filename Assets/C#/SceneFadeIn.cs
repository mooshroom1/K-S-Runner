using UnityEngine;
using UnityEngine.UI;

public class SceneFadeIn : MonoBehaviour
{
    public CanvasGroup canvasGroup; // ������ �� Canvas Group
    public float fadeDuration = 2.0f; // ������������ ���������

    private void Start()
    {
        // ��������, ��� ��������� ������������ 1
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
            canvasGroup.alpha = 1 - (timer / fadeDuration); // ��������� �����-�����
            yield return null;
        }

        canvasGroup.alpha = 0f; // ��������, ��� ��������� ���������
        canvasGroup.interactable = false; // ��������� ��������������
        DestroyObject(gameObject);
    }
}

