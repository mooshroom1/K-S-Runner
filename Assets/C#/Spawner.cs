using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;

    public Vector3 spawnPosition = Vector3.zero;
    public float spawnInterval = 2f;

    public float minY = -2f;
    public float maxY = 2f;

    public float speed = 3f;
    public float upSpeed = 0.1f;

    private float spawnTimer;  
    private float intervalTimer;  
    public float intervalReductionTime = 5f;  

    void Start()
    {
        spawnInterval = 2f;
        intervalTimer = 0f;
    }

    void Update()
    {
        
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            speed += upSpeed;
            Debug.Log($"Скорость изменена: {speed}");

            SpawnObject();
            spawnTimer = 0f;
        }

        
        intervalTimer += Time.deltaTime;
        if (intervalTimer >= intervalReductionTime)
        {
            spawnInterval -= 0.1f;
            spawnInterval = Mathf.Max(0.5f, spawnInterval); 
            Debug.Log($"Интервал изменен на: {spawnInterval}");
            intervalTimer = 0f;
        }
    }

    void SpawnObject()
    {
        if (prefabsToSpawn.Length == 0)
        {
            Debug.LogWarning("No prefabs assigned to spawner!");
            return;
        }

        int randomIndex = Random.Range(0, prefabsToSpawn.Length);

        float randomY = Random.Range(minY, maxY);

        Vector3 randomSpawnPosition = new Vector3(spawnPosition.x, spawnPosition.y + randomY, spawnPosition.z);

        GameObject newPlatform = Instantiate(prefabsToSpawn[randomIndex], randomSpawnPosition, Quaternion.identity);
        newPlatform.GetComponent<MoveLeft>().speed = speed;
    }
}
