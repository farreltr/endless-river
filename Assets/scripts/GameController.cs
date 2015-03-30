using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	private int numberOfPeople;
	private float time;
	private int seconds;
	private float distance;
	private Boat boat;
	private float initialDistance;
	private Text crewText;
	private Text timeText;
	private Text distanceText;
	private Text gameOverText;
	private bool gameOver = false;
	
	void Start ()
	{
		this.boat = GameObject.FindObjectOfType<Boat> ();
		this.initialDistance = boat.transform.position.x;
		this.numberOfPeople = Random.Range (1, 5) + Random.Range (1, 5);
		this.crewText = GameObject.FindWithTag ("Crew").GetComponent<Text> ();
		this.timeText = GameObject.FindWithTag ("Time").GetComponent<Text> ();
		this.distanceText = GameObject.FindWithTag ("Distance").GetComponent<Text> ();
		this.gameOverText = GameObject.FindWithTag ("Game Over").GetComponent<Text> ();
		gameOverText.enabled = false;
	}

	void Update ()
	{
		UpdateCrew ();
		UpdateDistance ();
		UpdateTime ();
	}

	void OnMouseDown ()
	{
		if (gameOver) {
			Application.LoadLevel (Application.loadedLevel);
		}
		
	}
	
	public void MoveBoatBack ()
	{
		boat.SetMoveBack (true);
		Vector3 turnPoint = boat.transform.position;
		turnPoint.x -= 0.5f;
		boat.SetTurnPoint (turnPoint);
	}

	private void UpdateTime ()
	{
		time += Time.deltaTime;
		seconds = Mathf.FloorToInt (time);	
		timeText.text = "Time : " + seconds;
	}

	private void UpdateDistance ()
	{
		distance = boat.transform.position.x - initialDistance;	
		distanceText.text = "Distance : " + System.Math.Round (distance, 2) + " meters";
	}


	private void UpdateCrew ()
	{
		crewText.text = "Crew Members : " + numberOfPeople;
	}

	
	public void StopBoat ()
	{
		boat.SetStopped (true);
	}
	
	public void StartBoat ()
	{
		boat.SetStopped (false);
	}
	

	public void AddPeopleToBoat (int n)
	{
		numberOfPeople += n;
	}

	public void RemovePeopleFromBoat (int n)
	{
		if (numberOfPeople - n <= 0) {
			gameOver = true;
			boat.SetGameOver (true);
			gameOverText.text = "Game Over!! You lasted for " + seconds + " seconds";
			gameOverText.enabled = true;

		} else {
			numberOfPeople -= n;
		}

	}

	public void SpeedUpBoat (float speedIncrease)
	{
		boat.SpeedUp (speedIncrease);
		boat.ReturnToNormalSpeed ();
	}

	
	public void SlowDownBoat (float speedDecrease)
	{
		boat.SlowDown (speedDecrease);
		boat.ReturnToNormalSpeed ();

	}

	public int GetNumberOfCrewMembers ()
	{
		return numberOfPeople;
	}
}
