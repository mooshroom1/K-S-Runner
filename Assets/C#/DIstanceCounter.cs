using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // ��� ������ � UI

public class DistanceCounter : MonoBehaviour
{
    public float speed = 3f;
    public Text distanceText;
    public Text bestScoreText;
    public Transform target;
    private Vector3 startPosition; // ��������� ������� �������
    private float distanceTraveled; // ���������� ����������
    private float bestScore;


    void Start()
    {
        // ���������� ��������� ������� �������
        if (target == null)
        {
            target = transform; // ���� ���� �� �������, ������������ ������� ������
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

