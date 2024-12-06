using UnityEngine;
using UnityEngine.SceneManagement; // Для работы с управлением сценами

public class Player : MonoBehaviour
{
    // Метод для уничтожения игрока
    public void DestroyPlayer()
    {
        // Уничтожаем объект игрока
        Destroy(gameObject);

        // Перезапускаем сцену через небольшую задержку
        Invoke("RestartScene", 2f);
    }

    // Метод для перезапуска сцены
    private void RestartScene()
    {
        // Перезапускаем текущую активную сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Пример: уничтожаем игрока при столкновении с врагом
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Если игрок сталкивается с объектом с тегом "Enemy"
        {
            DestroyPlayer();
        }
    }
}