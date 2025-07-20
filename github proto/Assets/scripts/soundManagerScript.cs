using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class soundManagerScript : MonoBehaviour
{
    [SerializeField] private List<AudioClip> musicClips = new List<AudioClip>(), sfxClips = new List<AudioClip>();
    [SerializeField] public AudioSource music, sfx;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        playMusicClip(0);
    }

    public void playMusicClip(int clipIndex)
    {
        music.clip = musicClips[clipIndex];
        music.Play();
    }

    public void playSfxClip(int clipIndex)
    {
        sfx.PlayOneShot(sfxClips[clipIndex]);
    }
}
