using UnityEngine;
using System.Collections;

public class DoorFall : MonoBehaviour
{
	private Transform _transform;
	private bool _doTrigger = true;
	private Quaternion _targetRotation;
	
	// Use this for initialization
	void Awake()
	{
		_transform = transform;
		_targetRotation = Quaternion.Euler(new Vector3(-0.35f, 15.3f, -76.0f));
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && _doTrigger)
		{
			_doTrigger = false;
			StartCoroutine(DoFall());
		}
	}
	
	private IEnumerator DoFall()
	{
		float time = 0.0f;
		float rate = 1.0f;
		Quaternion fromRotation = _transform.localRotation;
		
		while (time < 1.0f)
		{
			time += Time.deltaTime / rate;
			_transform.localRotation = Quaternion.Slerp(fromRotation, _targetRotation, time);
			yield return null;
		}
	}
}
