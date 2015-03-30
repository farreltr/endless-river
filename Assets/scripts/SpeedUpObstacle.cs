using UnityEngine;
using System.Collections;

public class SpeedUpObstacle : MonoBehaviour
{

	private float speedIncrease = 0.15f;
	private GameController controller;
	
	void Start ()
	{
		this.controller = GameObject.FindObjectOfType<GameController> ();
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		controller.SpeedUpBoat (speedIncrease);
		this.GetComponent<Collider2D>().enabled = false;
	}

}
