using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class PlayMusic : MonoBehaviour {
	
	public AudioClip[] musicClips;					//Array por si meto mas canciones
	public AudioMixerSnapshot volumeDown;			//Audio Mixer
	public AudioMixerSnapshot volumeUp;				//Ref Audio mixer


	private AudioSource musicSource;				//Ref Source

	void Awake () 
	{
		musicSource = GetComponent<AudioSource> ();
	}
	
	//Por si esta todo en la misma escena, poder elegir el clip de audio
	public void PlaySelectedMusic(int musicChoice)
	{
		musicSource.clip = musicClips [musicChoice];

		musicSource.Play ();
	}

	public void FadeUp(float fadeTime)
	{
		//volume UP
		volumeUp.TransitionTo (fadeTime);
	}

	public void FadeDown(float fadeTime)
	{
		//volume DOWN
		volumeDown.TransitionTo (fadeTime);
	}
}
