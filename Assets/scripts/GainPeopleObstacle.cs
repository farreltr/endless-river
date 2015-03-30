using UnityEngine;
using System.Collections;

public class GainPeopleObstacle : MonoBehaviour
{
	public int numberOfPeopleGained = 3;
	private GameController controller;

	void Start ()
	{
		this.controller = GameObject.FindObjectOfType<GameController> ();
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		controller.AddPeopleToBoat (numberOfPeopleGained);
		this.collider2D.enabled = false;
	}

}
