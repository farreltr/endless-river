using UnityEngine;
using System.Collections;
using Fungus;

public class Trigger : MonoBehaviour
{

	private FungusScript script;
	private MoveRight boat;

	void Start ()
	{
		script = GetComponent<FungusScript> ();
		boat = GameObject.FindObjectOfType<MoveRight> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		script.SetBooleanVariable ("Go", false);
		script.ExecuteSequence ("Bridge 1");
		Destroy (this.GetComponent<BoxCollider2D> ());
	}
}
