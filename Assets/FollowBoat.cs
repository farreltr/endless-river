using UnityEngine;
using System.Collections;

public class FollowBoat : MonoBehaviour {

    public GameObject target;

    void LateUpdate()
    {
        Camera.main.transform.position = new Vector3(target.transform.position.x, 0f, 0f); ;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
 
 
