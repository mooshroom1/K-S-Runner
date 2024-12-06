using UnityEngine;
using UnityEngine.UI; // Для работы с UI

public class DistanceCounter : MonoBehaviour
{
    public Text distanceText; // Ссылка на UI текст для отображения расстояния
    public Transform target;  // Объект, расстояние которого нужно считать
    private Vector3 startPosition; // Начальная позиция объекта
    private float distanceTraveled; // Пройденное расстояние

    void Start()
    {
        // Запоминаем начальную позицию объекта
        if (target == null)
        {
            target = transform; // Если цель не указана, использовать текущий объект
        }
        startPosition = target.position;
    }

    void Update()
    {
        // Вычисляем пройденное расстояние по оси X
        distanceTraveled = Vector3.Distance(new Vector3(startPosition.x, 0, 0), new Vector3(target.position.x, 0, 0));

        // Обновляем текст UI
        if (distanceText != null)
        {
            distanceText.text = "Distance: " + distanceTraveled.ToString("F2") + "m"; // Форматируем до 2 знаков после запятой
        }
    }
}
