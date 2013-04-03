using UnityEngine;
using System.Collections;

public class BlanketScript : MonoBehaviour {
	int timer = 50;
	int maxTimer = 100;
	int counter = -1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, 0.01f * (timer - maxTimer/2));
		timer += counter;
		if(timer == 0)
			counter = 1;
		if(timer == maxTimer)
			counter = -1;
		
	}
}
