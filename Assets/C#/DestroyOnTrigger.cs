using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Destroy(collision.gameObject);
        }     
    }    
}