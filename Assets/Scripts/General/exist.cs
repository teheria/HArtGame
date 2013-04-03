using UnityEngine;
using System.Collections;

public class exist : MonoBehaviour {

	public GameObject[] items = new GameObject[9];
	public AudioClip _flatline;
	public GameObject heartBox;
	public Texture2D flatlineTexture;
	
	static int counter = 0;
	public bool seenCounter = false;
	public bool faded = false;
	
	void Awake()
	{
		if (counter > 8)
		{
			audio.volume = 1.0f;
		}
		
		for (int i = 0; i < counter; ++i)
		{
			items[i].SetActive(true);
		}
	}
	
	void Start()
	{		
		if (counter < 9)
		{
			StartCoroutine(end());
		}
	}
	void Update()
	{
		if(faded) return;
		if(counter >= 9)
		{
			if(!Physics.Raycast(new Ray(transform.position, transform.forward), 1000, 1 << LayerMask.NameToLayer("Collect")))
			{
				if(seenCounter)
				{
					audio.Stop();
					audio.clip = _flatline;
					heartBox.renderer.material.mainTexture = flatlineTexture;
					audio.loop = true;
					audio.Play();
					StartCoroutine(FadeManager.Instance.FadeOut(true));
					faded = true;
				}
			}
			else
			{
				seenCounter = true;
			}
		}
		
		
	}
	private IEnumerator end()
    {
        yield return new WaitForSeconds(5);
		yield return StartCoroutine(FadeManager.Instance.FadeOut(true));
		counter++;
        Application.LoadLevel ("Dreamscape");
    }
	
	
	
	
}
