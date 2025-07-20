using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class soundManagerScript : MonoBehaviour
{
    [SerializeField] private List<AudioClip> musicClips = new List<AudioClip>(), sfxClips = new List<AudioClip>();
    [SerializeField] public AudioSource title, main, game, sfx;
    private bool playedMain, playedGame;
    public string playing = " ";
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        title.clip = musicClips[0];
        main.clip = musicClips[1];
        game.clip = musicClips[2];
        playMusicClip(0);
    }

    public void playMusicClip(int clipIndex)
    {
        if (clipIndex == 0)
        {
            title.volume = 0;
            title.mute = false;
            if (playing.Equals(" ")) {
                title.volume = 0.5f;
                StartCoroutine(fadeIn(title, 0, 0.5f));
            } 
            else StartCoroutine(fadeIn(title, 1f));
            title.Play();
            if (playing.Equals("main")) StartCoroutine(fadeOut(main));
            else if (playing.Equals("game")) StartCoroutine(fadeOut(game));
            playing = "title";
        }
        else if (clipIndex == 1 && !playedMain)
        {
            main.volume = 0;
            StartCoroutine(fadeIn(main, 1f));
            main.Play();
            if (playing.Equals("title")) StartCoroutine(fadeOut(title));
            else if (playing.Equals("game")) StartCoroutine(fadeOut(game));
            main.mute = false;
            playedMain = true;
            playing = "main";
        }
        else if (clipIndex == 1 && playedMain)
        {
            StartCoroutine(fadeIn(main, 1f));
            if (playing.Equals("title")) StartCoroutine(fadeOut(title));
            else if (playing.Equals("game")) StartCoroutine(fadeOut(game));
            main.mute = false;
            playing = "main";
        }
        else if (clipIndex == 2 && !playedGame)
        {
            game.volume = 0;
            StartCoroutine(fadeIn(game, 1f));
            game.Play();
            if (playing.Equals("title")) StartCoroutine(fadeOut(title));
            else if (playing.Equals("main")) StartCoroutine(fadeOut(main));
            game.mute = false;
            playedGame = true;
            playing = "game";
        }
        else if (clipIndex == 2 && playedGame)
        {
            if (playing.Equals("title")) StartCoroutine(fadeOut(title));
            else if (playing.Equals("main")) StartCoroutine(fadeOut(main));
            game.mute = false;
            playing = "game";
        }
    }

    private IEnumerator fadeIn(AudioSource audioSource, float delay)
    {
        yield return new WaitForSeconds(delay);
        float timePassed = 0;
        while (audioSource.volume < PlayerPrefs.GetFloat("musicVolume"))
        {
            audioSource.volume = Mathf.Lerp(0, PlayerPrefs.GetFloat("musicVolume"), timePassed / 1f);
            timePassed += Time.deltaTime;
            yield return new WaitForSeconds(0);
        }
    }

    private IEnumerator fadeIn(AudioSource audioSource, float delay, float startVolume)
    {
        yield return new WaitForSeconds(delay);
        float timePassed = 0;
        while (audioSource.volume < PlayerPrefs.GetFloat("musicVolume"))
        {
            audioSource.volume = Mathf.Lerp(startVolume, PlayerPrefs.GetFloat("musicVolume"), timePassed / 1f);
            timePassed += Time.deltaTime;
            yield return new WaitForSeconds(0);
        }
    }

    private IEnumerator fadeOut(AudioSource audioSource)
    {
        float timePassed = 0;
        while (audioSource.volume > 0)
        {
            audioSource.volume = Mathf.Lerp(PlayerPrefs.GetFloat("musicVolume"), 0, timePassed / 1f);
            timePassed += Time.deltaTime;
            yield return new WaitForSeconds(0);
        }
        audioSource.mute = true;
    }

    public void playSfxClip(int clipIndex)
    {
        sfx.PlayOneShot(sfxClips[clipIndex]);
    }
}
