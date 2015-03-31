using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour
{
	
	private float tileSize = 1.4f;
	private Vector3 currPos;
	private int numberOfTiles;
	private Vector3 boatPos;
	private Boat boat;
	private float delay;
	public int tileNumber;

	void Start ()
	{

		boat = GameObject.FindObjectOfType<Boat> ();
		boatPos = boat.transform.position;
		currPos = transform.position;
		numberOfTiles = transform.parent.childCount;
		delay = tileSize * (numberOfTiles - tileNumber);
		boatPos.x -= delay;
	}

	void Update ()
	{
		float pos = boat.transform.position.x - boatPos.x;
		if (pos > tileSize * numberOfTiles) {
			currPos.x = transform.position.x + (tileSize * numberOfTiles);
			transform.position = currPos;
			boatPos = boat.transform.position;
		}
	}
}
