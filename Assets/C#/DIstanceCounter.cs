using UnityEngine;
using UnityEngine.UI; // ��� ������ � UI

public class DistanceCounter : MonoBehaviour
{
    public Text distanceText; // ������ �� UI ����� ��� ����������� ����������
    public Transform target;  // ������, ���������� �������� ����� �������
    private Vector3 startPosition; // ��������� ������� �������
    private float distanceTraveled; // ���������� ����������

    void Start()
    {
        // ���������� ��������� ������� �������
        if (target == null)
        {
            target = transform; // ���� ���� �� �������, ������������ ������� ������
        }
        startPosition = target.position;
    }

    void Update()
    {
        // ��������� ���������� ���������� �� ��� X
        distanceTraveled = Vector3.Distance(new Vector3(startPosition.x, 0, 0), new Vector3(target.position.x, 0, 0));

        // ��������� ����� UI
        if (distanceText != null)
        {
            distanceText.text = "Distance: " + distanceTraveled.ToString("F2") + "m"; // ����������� �� 2 ������ ����� �������
        }
    }
}
