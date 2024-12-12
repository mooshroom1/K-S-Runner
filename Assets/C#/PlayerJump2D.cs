using UnityEngine;

public class PlayerJump2D : MonoBehaviour
{
    public float maxJumpForce = 10f; 
    public float minJumpForce = 2f; 
    public float chargeTime = 1f; 
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public Animator animator;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isCharging;
    private float chargeAmount; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        Application.targetFrameRate = 120;
    }

    void Update()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        animator.SetFloat("verticalVelocity", rb.velocity.y);

        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            isCharging = true;
            chargeAmount = 0f; 
        }

        if (Input.GetMouseButton(0) && isCharging)
        {
            chargeAmount += Time.deltaTime / chargeTime; 
            chargeAmount = Mathf.Clamp01(chargeAmount); 
        }

        
        if (Input.GetMouseButtonUp(0) && isCharging)
        {
            Jump();
            isCharging = false;
        }
    }

    void Jump()
    {
        
        float jumpForce = Mathf.Lerp(minJumpForce, maxJumpForce, chargeAmount);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        animator.SetTrigger("Jumping");
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