using UnityEngine;

public class InfiniteRoad2D : MonoBehaviour
{
    public ObjectPool objectPool; // Ссылка на пул объектов
    public float platformWidth = 10f; // Ширина одной платформы
    public int initialPlatforms = 5; // Количество платформ при старте
    public float speed = 5f; // Скорость движения дороги

    private float spawnX = 0f; // Координата X для спавна новых платформ
    private float despawnX = -15f; // Координата X для удаления старых платформ

    void Start()
    {
        // Создаем начальные платформы
        for (int i = 0; i < initialPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // Двигаем платформы влево
        foreach (Transform child in transform)
        {
            child.Translate(Vector3.left * speed * Time.deltaTime);

            // Возвращаем платформу в пул, если она уходит за пределы экрана
            if (child.position.x < despawnX)
            {
                objectPool.ReturnToPool(child.gameObject);
                child.gameObject.transform.SetParent(null);
                SpawnPlatform();
            }
        }
    }

    void SpawnPlatform()
    {
        // Забираем платформу из пула
        GameObject platform = objectPool.GetObject();
        platform.transform.position = new Vector3(spawnX, Random.Range(-1f, 1f), 0); // Рандомное смещение по оси Y
        platform.transform.SetParent(transform);
        spawnX += platformWidth; // Увеличиваем координату спавна
    }
}
