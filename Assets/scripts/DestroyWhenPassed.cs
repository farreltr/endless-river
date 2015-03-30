using UnityEngine;
using System.Collections;

public class DestroyWhenPassed : MonoBehaviour
{

	private Boat boat;
	private float tileSize = 2.61f;

	void Start ()
	{
		boat = FindObjectOfType<Boat> ();
	}

	void Update ()
	{
		if (transform.position.x < (boat.transform.position.x - tileSize)) {
			Destroy (this.gameObject);
		}
	
	}
}
