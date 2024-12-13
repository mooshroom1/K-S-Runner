using UnityEngine;

public class ChangeTransparency : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Ссылка на SpriteRenderer
    public float transparency = 0.5f; // Прозрачность (0 = полностью прозрачный, 1 = полностью непрозрачный)

    void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        Color color = spriteRenderer.color;
        color.a = transparency; // Устанавливаем значение альфа-канала
        spriteRenderer.color = color; // Применяем изменения
    }
}
