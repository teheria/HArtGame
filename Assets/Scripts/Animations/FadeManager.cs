using UnityEngine;
using System.Collections;

public class FadeManager : Singleton<FadeManager>
{
	public Texture2D black;
	public Texture2D white;
	
	private Texture2D _currentTexture;
	private float _fadeSpeed = 0.3f;
	private float _alpha = 1.0f;
	private float _rgb;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(FadeIn(true));
	}
	
	void OnGUI()
	{
		Color temp = new Color(_rgb, _rgb, _rgb, _alpha);
		GUI.color = temp;
		GUI.depth = -1000;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _currentTexture);
	}
	
	public IEnumerator FadeIn(bool isBlack)
	{
		if (isBlack)
		{
			_currentTexture = black;
			_rgb = 0.0f;
		}
		else
		{
			_currentTexture = white;
			_rgb = 1.0f;
		}
		
		_alpha = 1.0f;
		while (_alpha > 0.0f)
		{
			_alpha += -1.0f * _fadeSpeed * Time.deltaTime;
			_alpha = Mathf.Clamp01(_alpha);
			yield return null;
		}
	}
	
	public IEnumerator FadeOut(bool isBlack)
	{
		if (isBlack)
		{
			_currentTexture = black;
			_rgb = 0.0f;
		}
		else
		{
			_currentTexture = white;
			_rgb = 1.0f;
		}
		
		_alpha = 0.0f;
		while (_alpha < 1.0f)
		{
			_alpha += 1.0f * _fadeSpeed * Time.deltaTime;
			_alpha = Mathf.Clamp01(_alpha);
			yield return null;
		}
	}
}
