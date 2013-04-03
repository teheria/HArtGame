using UnityEngine;
using System.Collections;

public class HeartMonitorScript : MonoBehaviour {
	public float scrollPerFrame = 0.1f;
	float currScroll = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.SetTextureOffset("_MainTex", new Vector2(currScroll, 0));
		currScroll += scrollPerFrame;
	}
}
