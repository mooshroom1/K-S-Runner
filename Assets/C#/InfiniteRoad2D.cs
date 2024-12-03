using UnityEngine;

public class InfiniteRoad2D : MonoBehaviour
{
    public ObjectPool objectPool; // ������ �� ��� ��������
    public float platformWidth = 10f; // ������ ����� ���������
    public int initialPlatforms = 5; // ���������� �������� ��� ������
    public float speed = 5f; // �������� �������� ������

    private float spawnX = 0f; // ���������� X ��� ������ ����� ��������
    private float despawnX = -15f; // ���������� X ��� �������� ������ ��������

    void Start()
    {
        // ������� ��������� ���������
        for (int i = 0; i < initialPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // ������� ��������� �����
        foreach (Transform child in transform)
        {
            child.Translate(Vector3.left * speed * Time.deltaTime);

            // ���������� ��������� � ���, ���� ��� ������ �� ������� ������
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
        // �������� ��������� �� ����
        GameObject platform = objectPool.GetObject();
        platform.transform.position = new Vector3(spawnX, Random.Range(-1f, 1f), 0); // ��������� �������� �� ��� Y
        platform.transform.SetParent(transform);
        spawnX += platformWidth; // ����������� ���������� ������
    }
}
