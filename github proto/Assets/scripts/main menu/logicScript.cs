using UnityEngine;
using UnityEngine.SceneManagement;

public class logicScript : MonoBehaviour
{
    [SerializeField] int sceneIndex;
    [SerializeField] private GameObject nonSettings, settings, soundManager;
    public void startGame()
    {
        soundManager.GetComponent<soundManagerScript>().playSfxClip(15);
        PlayerPrefs.SetInt("currentText", 0);
        SceneManager.LoadScene(1);
    }

    public void openSettings()
    {
        soundManager.GetComponent<soundManagerScript>().playSfxClip(15);
        nonSettings.SetActive(false);
        settings.SetActive(true);
    }

    public void closeSettings()
    {
        soundManager.GetComponent<soundManagerScript>().playSfxClip(15);
        nonSettings.SetActive(true);
        settings.SetActive(false);
    }

    public void testSfx()
    {
        soundManager.GetComponent<soundManagerScript>().playSfxClip(15);
        soundManager.GetComponent<soundManagerScript>().playSfxClip(18);
    }

    public void changeMusicVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("musicVolume", newVolume);
        soundManager.GetComponent<soundManagerScript>().title.volume = newVolume;
        soundManager.GetComponent<soundManagerScript>().main.volume = newVolume;
        soundManager.GetComponent<soundManagerScript>().game.volume = newVolume;
    }
    
    public void changeSfxVolume(float newVolume)
    {
        soundManager.GetComponent<soundManagerScript>().sfx.volume = newVolume;
    }
}
