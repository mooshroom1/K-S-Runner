using UnityEngine;
using UnityEngine.SceneManagement; 

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {
            Destroy(gameObject);
        }
    }
}