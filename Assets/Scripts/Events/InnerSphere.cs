using UnityEngine;
using System.Collections;

public class InnerSphere : MonoBehaviour
{
	public GameObject player;
	public OutterSphere outterSphere;
	public Renderer waveEffect;
	
	void Awake()
	{
		outterSphere.InnerRadius = GetComponent<SphereCollider>().radius;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)
		{
			waveEffect.material.SetFloat("_Rim", 1.5f);
			outterSphere.IsOnlyInOutter = false;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player)
		{
			outterSphere.IsOnlyInOutter = true;
		}
	}
}
