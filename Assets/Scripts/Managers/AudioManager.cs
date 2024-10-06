using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[System.Serializable]
	public class Sound
	{
		public string name;
		public AudioClip clip;
	}

	private static AudioManager instance;
	public static AudioManager Instance { get { return instance; } }

	public Sound[] musicSounds, sfxSounds;
	public AudioSource musicSource, sfxSource;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void PlayMusic(string name)
	{
		Sound sound = Array.Find(musicSounds, musicSound => musicSound.name == name);
		if (sound != null)
		{
			musicSource.clip = sound.clip;
			musicSource.Play();
		}
	}

	public void PlaySFX(string name)
	{
		Sound sound = Array.Find(sfxSounds, sfxSound => sfxSound.name == name);
		if (sound != null)
		{
			sfxSource.PlayOneShot(sound.clip);
		}
	}
}
