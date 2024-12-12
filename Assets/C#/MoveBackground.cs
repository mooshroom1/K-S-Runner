using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {



	public float speed;
	private float x;
	public float PontoDeDestino;
	public float PontoOriginal;
	public float speedIncreaseInterval = 2f; 
	public float speedIncreaseAmount = 0.1f; 

	private float nextSpeedIncreaseTime;



	// Use this for initialization
	void Start () {
		//PontoOriginal = transform.position.x;
		nextSpeedIncreaseTime = Time.time + speedIncreaseInterval;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Time.time >= nextSpeedIncreaseTime)
		{
			speed += speedIncreaseAmount;
			nextSpeedIncreaseTime = Time.time + speedIncreaseInterval; 
		}

		x = transform.position.x;
		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);



		if (x <= PontoDeDestino){

			Debug.Log ("hhhh");
			x = PontoOriginal;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}


	}
}
