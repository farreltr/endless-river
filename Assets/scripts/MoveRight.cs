using UnityEngine;
using System.Collections;
using Fungus;

public class MoveRight : MonoBehaviour
{

	private Vector3 direction = Vector2.right;
	private float speed = 0.5f;
	//private FungusScript script;
	
	void Start ()
	{
		//script = GameObject.FindObjectOfType<FungusScript> ();
		//script.SetBooleanVariable ("Go", true);
	}




	public void Stop ()
	{
		speed = 0.0f;
	}

	public void Red ()
	{
		GetComponent<SpriteRenderer> ().material.color = Color.red;
	}

	public void Go ()
	{
		speed = 0.5f;
	}
}
