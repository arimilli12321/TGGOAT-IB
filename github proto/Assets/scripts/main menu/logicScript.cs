using UnityEngine;
using UnityEngine.SceneManagement;

public class logicScript : MonoBehaviour
{
    [SerializeField] int sceneIndex;
    [SerializeField] private GameObject nonSettings, settings, soundManager;
    public void startGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void openSettings()
    {
        nonSettings.SetActive(false);
        settings.SetActive(true);
    }

    public void closeSettings()
    {
        nonSettings.SetActive(true);
        settings.SetActive(false);
    }

    public void changeMusicVolume(float newVolume)
    {
        soundManager.GetComponent<soundManagerScript>().music.volume = newVolume;
    }
    
    public void changeSfxVolume(float newVolume)
    {
        soundManager.GetComponent<soundManagerScript>().sfx.volume = newVolume;
    }
}
