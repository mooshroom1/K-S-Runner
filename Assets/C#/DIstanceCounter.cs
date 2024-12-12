using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // Для работы с UI

public class DistanceCounter : MonoBehaviour
{
    public float speed = 3f;
    public Text distanceText;
    public Text bestScoreText;
    public Transform target;
    private Vector3 startPosition; // Начальная позиция объекта
    private float distanceTraveled; // Пройденное расстояние
    private float bestScore;


    void Start()
    {
        // Запоминаем начальную позицию объекта
        if (target == null)
        {
            target = transform; // Если цель не указана, использовать текущий объект
        }
        startPosition = target.position;

        bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
        UpdateBestScoreText();
    }

    void Update()
    {

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        
        distanceTraveled = Vector3.Distance(new Vector3(startPosition.x, 0, 0), new Vector3(target.position.x, 0, 0));
        distanceText.text = "Score: " + distanceTraveled.ToString("F0");

        
        if (distanceTraveled > bestScore)
        {
            bestScore = distanceTraveled;
            UpdateBestScoreText();

            
            PlayerPrefs.SetFloat("BestScore", bestScore);
            PlayerPrefs.Save();
        }

    }
    void UpdateBestScoreText()
    {
        bestScoreText.text = "Best Score: " + bestScore.ToString("F0");
    }

}

