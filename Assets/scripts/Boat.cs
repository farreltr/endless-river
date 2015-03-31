using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Boat : MonoBehaviour
{
	private Vector3 direction = Vector2.right;
	public float speed;
	public float originalSpeed = 0.45f;
	public float speedUpTime = 5f;
	private Vector3 screenPoint;
	private Vector3 offset;
	public float upperBound = 0.1f;
	public float lowerBound = -0.1f;
	private bool moveBack = false;
	private Vector3 turnPoint;
	private bool stopped = false;
	private bool gameOver = false;


  float lockPos = 0;


	    void Start ()
	{
    
		speed = originalSpeed;
	}


     
	void FixedUpdate ()
	{
		if (moveBack) {
			Vector3 movement = direction * -2f * speed;
			movement *= Time.deltaTime;
			transform.Translate (movement);
			SetMoveBack (transform.position.x > turnPoint.x);
		} else if (!stopped && !gameOver) {
			Vector3 movement = direction * speed;
			movement *= Time.deltaTime;
			transform.Translate (movement);	
		}

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(Mathf.Clamp(angle,-45f, 45f), Vector3.forward); 
 

	}

	public void SetTurnPoint (Vector3 turnPoint)
	{
		this.turnPoint = turnPoint;
	}
		
	void OnMouseDown ()
	{
		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (screenPoint.x, Input.mousePosition.y, screenPoint.z));
		
	}
	
	void OnMouseDrag ()
	{
		Vector3 curScreenPoint = new Vector3 (screenPoint.x, Input.mousePosition.y, screenPoint.z);		
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
		transform.position = OutOfBounds (curPosition);
	}

	Vector3 OutOfBounds (Vector3 curPosition)
	{
		if (curPosition.y > upperBound) {
			curPosition.y = upperBound;
		}
		if (curPosition.y < lowerBound) {
			curPosition.y = lowerBound;
		}
		return curPosition;
	}

	public void SetMoveBack (bool moveBack)
	{
		this.moveBack = moveBack;
	}

	public void SetStopped (bool stopped)
	{
		this.stopped = stopped;
	}

	public void SpeedUp (float increaseSpeed)
	{
		speed += increaseSpeed;
	}

	public void SlowDown (float decreaseSpeed)
	{
		speed -= decreaseSpeed;
	}

	public void SetGameOver (bool gameOver)
	{
		this.gameOver = gameOver;
	}

	public void ReturnToNormalSpeed ()
	{
		StartCoroutine ("NormalSpeed");
	}

	private IEnumerator NormalSpeed ()
	{
		yield return new WaitForSeconds (speedUpTime);
		speed = originalSpeed;

	}
}
