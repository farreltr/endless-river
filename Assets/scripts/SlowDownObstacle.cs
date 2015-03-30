using UnityEngine;
using System.Collections;

public class SlowDownObstacle : MonoBehaviour
{

	private float speedDecrease = 0.15f;
	private GameController controller;
	
	void Start ()
	{
		this.controller = GameObject.FindObjectOfType<GameController> ();
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		controller.SlowDownBoat (speedDecrease);
		this.collider2D.enabled = false;
	}
}
