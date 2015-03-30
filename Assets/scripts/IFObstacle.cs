﻿using UnityEngine;
using System.Collections;
using Fungus;

public class IFObstacle : MonoBehaviour
{
	private GameController controller;
	private FungusScript script;
	public string missionName;
	public int difficultyRatingMin;
	public int difficultyRatingMax;
	public int crewLosses;
	private bool isUpdated = false;

	void Start ()
	{
		this.controller = GameObject.FindObjectOfType<GameController> ();
		this.script = GetComponent<FungusScript> ();
	}

	void Update ()
	{
		if (!isUpdated && script.GetBooleanVariable ("doupdate")) {
			UpdateVariables ();
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		controller.StopBoat ();
		script.ExecuteSequence (missionName);
	}

	private bool CalculateWinValue ()
	{
		int difficultyRating = Random.Range (difficultyRatingMin, difficultyRatingMax + 1);

		int playerLevel = this.controller.GetNumberOfCrewMembers ();
		int playerRoll = Random.Range (1, 7);

		int diff = difficultyRating - (playerRoll + playerLevel);
		bool win = diff <= 0;
		crewLosses = Mathf.Abs (diff);
		return win;
	}

	private void UpdateVariables ()
	{
		if (!isUpdated) {
			if (!script.GetBooleanVariable ("fight")) {
				controller.RemovePeopleFromBoat (script.GetIntegerVariable ("crewloss"));
			} else {
				bool win = CalculateWinValue ();
				script.SetBooleanVariable ("win", win);
				script.SetIntegerVariable ("crewloss", crewLosses);
				if (!win) {
					controller.RemovePeopleFromBoat (crewLosses);
				}
			}
			isUpdated = true;
			script.SetBooleanVariable ("doupdate", false);
			controller.StartBoat ();
			GetComponent<BoxCollider2D> ().enabled = false;
		}

	}


}
