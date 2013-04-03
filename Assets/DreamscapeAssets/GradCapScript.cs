using UnityEngine;
using System.Collections;

public class GradCapScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.Rotate(new Vector3(0, Random.Range(0, 2 * Mathf.PI), 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
