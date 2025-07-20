using UnityEngine;
using UnityEngine.SceneManagement;

public class wrongWordsScript : MonoBehaviour
{
    [SerializeField] private guessScirpt guessScirpt;
    private soundManagerScript soundManager;

    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("soundManager").GetComponent<soundManagerScript>();
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (guessScirpt.isGuessing)
            {
                soundManager.playSfxClip(10);
                transform.Find("right sprite").gameObject.SetActive(true);
                guessScirpt.mistakesFound++;
                if (guessScirpt.mistakesFound == 2)
                {
                    PlayerPrefs.SetInt("currentText", 12);
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
}
