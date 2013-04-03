using UnityEngine;
using System.Collections;

public class WaveFade : MonoBehaviour
{
	private Renderer _renderer;
	
	// Use this for initialization
	void Awake() 
	{
		_renderer = renderer;	
	}
	
	void Start()
	{
		StartCoroutine(WaveFadeIn());
		/*float fov = transform.parent.camera.fieldOfView / 2;
		float aspectRatio = transform.parent.camera.aspect;
		
		float h = Mathf.Tan(fov * Mathf.Deg2Rad * 0.5f) * 0.3f * 2.0f;
		transform.localScale = new Vector3(h, 0.0f, h * aspectRatio);*/
	}
	
	public IEnumerator WaveFadeIn()
	{
		float time = 0.0f;
		_renderer.material.SetFloat("_Rim", time);
		
		while (time < 1.5f)
		{
			time += Time.deltaTime * 0.3f;
			_renderer.material.SetFloat("_Rim", time);
			yield return null;
		}
		
		_renderer.material.SetFloat("_Rim", 1.5f);
	}
	
	public IEnumerator WaveFadeOut()
	{
		float time = 1.5f;
		_renderer.material.SetFloat("_Rim", time);
		
		while (time > 0.0f)
		{
			time -= Time.deltaTime * 0.3f;
			_renderer.material.SetFloat("_Rim", time);
			yield return null;
		}
		
		_renderer.material.SetFloat("_Rim", 0.0f);
		Application.LoadLevel("Hospital");
	}
	
	public IEnumerator SetWaveAmount(float amount)
	{
		float time = _renderer.material.GetFloat("_Rim");
		
		if (amount > 1.5f)
		{
			StopCoroutine("SetWaveAmount");
		}
		
		if (amount < time)
		{
			while (amount < time)
			{
				time -= Time.deltaTime * 0.3f;
				_renderer.material.SetFloat("_Rim", time);
				yield return null;
			}
		}
		else
		{
			while (amount > time)
			{
				time += Time.deltaTime * 0.2f;
				_renderer.material.SetFloat("_Rim", time);
				yield return null;
			}
		}
		
		_renderer.material.SetFloat("_Rim", amount);
	}
}
