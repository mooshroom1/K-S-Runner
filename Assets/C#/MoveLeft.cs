using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 5f; // �������� ��������

    void Update()
    {
        // �������� ����� �� ��� X
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}