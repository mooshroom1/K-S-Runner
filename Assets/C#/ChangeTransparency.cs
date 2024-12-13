using UnityEngine;

public class ChangeTransparency : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // ������ �� SpriteRenderer
    public float transparency = 0.5f; // ������������ (0 = ��������� ����������, 1 = ��������� ������������)

    void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        Color color = spriteRenderer.color;
        color.a = transparency; // ������������� �������� �����-������
        spriteRenderer.color = color; // ��������� ���������
    }
}
