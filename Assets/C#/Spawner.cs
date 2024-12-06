using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject[] prefabsToSpawn;

   
    public Vector3 spawnPosition = Vector3.zero;
    public float spawnInterval = 2f;

    public float minY = -2f;
    public float maxY = 2f;


    private float timer;

    void Update()
    {
        
        timer += Time.deltaTime;

        
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f; 
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

        Instantiate(prefabsToSpawn[randomIndex], randomSpawnPosition, Quaternion.identity);
    }
}