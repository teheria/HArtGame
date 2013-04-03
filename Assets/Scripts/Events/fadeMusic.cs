using UnityEngine;
using System.Collections;

public class fadeMusic : MonoBehaviour
{
	public AudioSource mainAduio;
	
	private bool _doFade = true;

	void OnTriggerEnter(Collider other)
	{
		if (!_doFade) return;
		
		if (other.CompareTag("Player"))
		{
			_doFade = false;
			StartCoroutine(FadeSound());
		}
	}
	
	private IEnumerator FadeSound()
	{
		float vol = 1.0f;
		
		while (vol > 0.0f)
		{
			vol -= Time.deltaTime;
			mainAduio.volume = vol;
			yield return null;
		}
		
		mainAduio.volume = 0.0f;
	}
}
