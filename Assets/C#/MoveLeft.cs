using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour

{
    public float  speed = 3f;
    

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    } 
}
