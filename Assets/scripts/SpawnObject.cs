using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour
{

	public Transform[] IFobstacles;
	public Transform[] nonIFobstacles;
	private Boat boat;
	public float minTime = 5f;
	public float maxTime = 10f;
	private int count = 0;
	private int IFcount = 0;
	
	void Start ()
	{
		boat = transform.parent.GetComponent<Boat> ();
		IFcount = Random.Range (6, 10);
		Spawn ();
	
	}

	void Spawn ()
	{
		GameObject obj;
		if (count == IFcount) {
			int index = Random.Range (0, IFobstacles.Length);
			obj = IFobstacles [index].gameObject;
			count = 0;
			IFcount = Random.Range (6, 10);
		} else {
			int index = Random.Range (0, nonIFobstacles.Length);
			obj = nonIFobstacles [index].gameObject;
		}
		Vector3 pos = transform.position;
		pos.y = Random.Range (boat.lowerBound * 100f, boat.upperBound * 100f);
		pos.y = pos.y / 100f;
		pos.z = 0;

		if (BounceBack (obj, pos) || TooClose (pos)) {
			//ignore 
		} else {
			Instantiate (obj, pos, obj.transform.rotation);
		}
		count ++;
		Invoke ("Spawn", Random.Range (minTime, maxTime));
	}

	private bool BounceBack (GameObject obj, Vector3 pos)
	{
		return obj.GetComponent<LosePeopleObstacle> () != null && (pos.y < 0.05f && pos.y > -0.05f);
	}

	private bool TooClose (Vector3 pos)
	{
		DestroyWhenPassed[] obsts = GameObject.FindObjectsOfType<DestroyWhenPassed> ();
		foreach (DestroyWhenPassed go in obsts) {
			if (Mathf.Abs (go.gameObject.transform.position.x - pos.x) < 0.1f) {
				return true;
			}
		}
		return false;
	}
}
