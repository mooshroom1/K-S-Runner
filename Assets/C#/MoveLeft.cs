using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 5f; // Скорость движения

    void Update()
    {
        // Движение влево по оси X
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}