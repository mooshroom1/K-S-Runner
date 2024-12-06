using UnityEngine;
using UnityEngine.SceneManagement; // ��� ������ � ����������� �������

public class Player : MonoBehaviour
{
    // ����� ��� ����������� ������
    public void DestroyPlayer()
    {
        // ���������� ������ ������
        Destroy(gameObject);

        // ������������� ����� ����� ��������� ��������
        Invoke("RestartScene", 2f);
    }

    // ����� ��� ����������� �����
    private void RestartScene()
    {
        // ������������� ������� �������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ������: ���������� ������ ��� ������������ � ������
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // ���� ����� ������������ � �������� � ����� "Enemy"
        {
            DestroyPlayer();
        }
    }
}