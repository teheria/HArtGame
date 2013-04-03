using UnityEngine;
using System.Collections.Generic;

public class SoundSequencer : MonoBehaviour {
	public AudioSource source;
	public List<AudioClip> primaryAudio = new List<AudioClip>();
	public List<AudioClip> notes = new List<AudioClip>();
	int mode = 0;
	public int delay = 100;
	public int timer = 0;
	public bool skipFourth = true;
	int timesUsed = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(timer <= 0)
		{
			if(timesUsed != 4 || !skipFourth)
			{
				mode += 1 + (int)Random.Range(0, 5) * 2 - 4;
				while(mode >= primaryAudio.Count)
					mode -= primaryAudio.Count;
				while(mode < 0)
					mode += primaryAudio.Count;
				source.PlayOneShot(primaryAudio[mode]);
			}
			else
				timesUsed = 0;
			++timesUsed;
			timer = delay;
		}
		--timer;
	}
}
