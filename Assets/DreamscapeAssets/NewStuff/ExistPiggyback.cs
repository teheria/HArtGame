using UnityEngine;
using System.Collections;

public class ExistPiggyback : MonoBehaviour {
	
	public GameObject target;
	// Use this for initialization
	void Start () {
		gameObject.SetActive(target.activeSelf);
	}
}
