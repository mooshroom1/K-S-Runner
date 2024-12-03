using UnityEngine;

public class PlayerJump2D : MonoBehaviour
{
    public float jumpForce = 5f; // Сила прыжка
    public LayerMask groundLayer; // Слой земли
    public Transform groundCheck; // Точка проверки земли
    public float groundCheckRadius = 0.2f; // Радиус проверки земли

    private Rigidbody2D rb; // Компонент Rigidbody2D
    private bool isGrounded; // Проверка, на земле ли объект

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D
    }

    void Update()
    {
        // Проверка, на земле ли объект
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Прыжок при нажатии пробела
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Придаем скорость вверх
    }

    void OnDrawGizmosSelected()
    {
        // Рисуем радиус проверки земли в редакторе
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}