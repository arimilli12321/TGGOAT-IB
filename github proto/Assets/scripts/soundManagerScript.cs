using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class soundManagerScript : MonoBehaviour
{
    [SerializeField] private List<AudioClip> musicClips = new List<AudioClip>(), sfxClips = new List<AudioClip>();
    [SerializeField] public AudioSource title, main, game, sfx;
    private bool playedMain, playedGame;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        title.clip = musicClips[0];
        main.clip = musicClips[1];
        game.clip = musicClips[2];
        playMusicClip(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) playMusicClip(0);
        else if (Input.GetKeyDown(KeyCode.B)) playMusicClip(1);
        else if (Input.GetKeyDown(KeyCode.C)) playMusicClip(2);
    }

    public void playMusicClip(int clipIndex)
    {
        if (clipIndex == 0)
        {
            title.Play();
            main.mute = true;
            game.mute = true;
        }
        else if (clipIndex == 1 && !playedMain)
        {
            main.Play();
            main.mute = false;
            title.Stop();
            game.mute = true;
            playedMain = true;
        }
        else if (clipIndex == 1 && playedMain)
        {
            main.mute = false;
            title.Stop();
            game.mute = true;
        }
        else if (clipIndex == 2 && !playedGame)
        {
            game.Play();
            game.mute = false;
            title.Stop();
            main.mute = true;
            playedGame = true;
        }
        else if (clipIndex == 2 && playedGame)
        {
            game.mute = false;
            title.Stop();
            main.mute = true;
        }

    }

    public void playSfxClip(int clipIndex)
    {
        sfx.PlayOneShot(sfxClips[clipIndex]);
    }
}
