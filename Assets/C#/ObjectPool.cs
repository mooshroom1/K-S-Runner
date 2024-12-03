using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] platformPrefabs; // Массив различных префабов платформ
    public int poolSize = 10; // Количество платформ в пуле
    private Queue<GameObject> pool = new Queue<GameObject>(); // Очередь для объектов

    void Start()
    {
        // Инициализация пула
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)]);
            obj.SetActive(false); // Отключаем объект, пока он не нужен
            pool.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        // Забираем объект из пула
        GameObject obj = pool.Dequeue();
        obj.SetActive(true);
        pool.Enqueue(obj);
        return obj;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false); // Отключаем объект
        pool.Enqueue(obj);
    }
}
