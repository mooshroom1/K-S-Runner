using UnityEngine;

public class PlayerJump2D : MonoBehaviour
{
    public float maxJumpForce = 10f; 
    public float minJumpForce = 2f; 
    public float chargeTime = 1f; 
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isCharging;
    private float chargeAmount; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isCharging = true;
            chargeAmount = 0f; 
        }

        if (Input.GetKey(KeyCode.Space) && isCharging)
        {
            chargeAmount += Time.deltaTime / chargeTime; 
            chargeAmount = Mathf.Clamp01(chargeAmount); 
        }

        
        if (Input.GetKeyUp(KeyCode.Space) && isCharging)
        {
            Jump();
            isCharging = false;
        }
    }

    void Jump()
    {
        
        float jumpForce = Mathf.Lerp(minJumpForce, maxJumpForce, chargeAmount);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void OnDrawGizmosSelected()
    {
        
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}