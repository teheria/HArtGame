using UnityEngine;
using System.Collections;

public class WakeUpRotate : MonoBehaviour
{
	public Transform targetRotation;
	
	private Transform _transform;
	private float _rate = 2.0f;
	
	// Use this for initialization
	void Awake()
	{
		_transform = transform;
	}
	
	void Start()
	{
		StartCoroutine(WakeUp());
	}
	
	public IEnumerator WakeUp()
	{
		float time = 0.0f;
		Quaternion fromRotation = _transform.localRotation;

		while (time < 1.0f)
		{
			time += Time.deltaTime / _rate;
			_transform.localRotation = Quaternion.Slerp(fromRotation, targetRotation.localRotation, time);
			yield return null;
		}
	}
}
