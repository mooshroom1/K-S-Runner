using UnityEngine;
using UnityEngine.UI; // Для работы с UI

public class DistanceCounter : MonoBehaviour
{
    public Text distanceText; 
    public Transform target;  
    private Vector3 startPosition; 
    private float distanceTraveled; 
    void Start()
    {
        
        if (target == null)
        {
            target = transform; 
        }
        startPosition = target.position;
    }

    void Update()
    {
        
        distanceTraveled = Vector3.Distance(new Vector3(startPosition.x, 0, 0), new Vector3(target.position.x, 0, 0));

      
        if (distanceText != null)
        {
            distanceText.text = "Distance: " + distanceTraveled.ToString("F2") + "m"; 
        }
    }
}
