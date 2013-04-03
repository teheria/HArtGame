using UnityEngine;
using System.Collections;

public class SlidingDoor : MonoBehaviour {
	public Transform player;
	public float threshold = 3;
	public float speed = 0.01f;
	bool moving = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(moving) 
			transform.localPosition += new Vector3(0, 0, speed);
		if(Vector3.Distance(transform.position, player.position) < threshold)
			moving = true;
	}
}
