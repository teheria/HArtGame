using UnityEngine;
using System.Collections;

public class OutterSphere : MonoBehaviour
{
	public GameObject player;
	public Renderer waveEffect;
	
	private bool _isOnlyInOutter = false;
	private float _innerRadius = 0.0f;
	private float _outterRadius = 0.0f;
	
	public bool IsOnlyInOutter
	{
		get { return _isOnlyInOutter; }
		set { _isOnlyInOutter = value; }
	}
	
	public float InnerRadius
	{
		get { return _innerRadius; }
		set { _innerRadius = value; }
	}
	
	void Start()
	{
		_outterRadius = GetComponent<SphereCollider>().radius - _innerRadius;
	}
	
	void OnTriggerStay(Collider other)
	{
		if (_isOnlyInOutter && other.gameObject == player)
		{
			float distance = Vector3.Distance(player.transform.position, transform.position);
			distance -= _innerRadius;
			float waveInfluence = ((_outterRadius - distance) / _outterRadius) * 1.5f;
			//Debug.Log(waveInfluence);
			waveEffect.material.SetFloat("_Rim", waveInfluence);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player)
		{
			waveEffect.material.SetFloat("_Rim", 0.0f);
			// do teleport
		}
	}
}
