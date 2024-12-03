using UnityEngine;

public class PlayerJump2D : MonoBehaviour
{
    public float jumpForce = 5f; // ���� ������
    public LayerMask groundLayer; // ���� �����
    public Transform groundCheck; // ����� �������� �����
    public float groundCheckRadius = 0.2f; // ������ �������� �����

    private Rigidbody2D rb; // ��������� Rigidbody2D
    private bool isGrounded; // ��������, �� ����� �� ������

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // �������� ��������� Rigidbody2D
    }

    void Update()
    {
        // ��������, �� ����� �� ������
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // ������ ��� ������� �������
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // ������� �������� �����
    }

    void OnDrawGizmosSelected()
    {
        // ������ ������ �������� ����� � ���������
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}