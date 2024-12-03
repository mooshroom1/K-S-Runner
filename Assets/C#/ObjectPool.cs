using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] platformPrefabs; // ������ ��������� �������� ��������
    public int poolSize = 10; // ���������� �������� � ����
    private Queue<GameObject> pool = new Queue<GameObject>(); // ������� ��� ��������

    void Start()
    {
        // ������������� ����
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)]);
            obj.SetActive(false); // ��������� ������, ���� �� �� �����
            pool.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        // �������� ������ �� ����
        GameObject obj = pool.Dequeue();
        obj.SetActive(true);
        pool.Enqueue(obj);
        return obj;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false); // ��������� ������
        pool.Enqueue(obj);
    }
}
