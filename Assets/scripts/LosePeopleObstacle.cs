using UnityEngine;
using System.Collections;

public class LosePeopleObstacle : MonoBehaviour
{
	public int numberOfPeopleLost = 3;
	private GameController controller;

	void Start ()
	{
		this.controller = GameObject.FindObjectOfType<GameController> ();
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		controller.RemovePeopleFromBoat (numberOfPeopleLost);
		controller.MoveBoatBack ();
	}

}
