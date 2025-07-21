using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class wrongWordsScript : MonoBehaviour
{
    [SerializeField] private guessScirpt guessScirpt;
    private soundManagerScript soundManager;
    [SerializeField] private GameObject camera_, canvas;

    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("soundManager").GetComponent<soundManagerScript>();
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            soundManager.playSfxClip(10);
            transform.Find("right sprite").gameObject.SetActive(true);
            guessScirpt.mistakesFound++;
            if (guessScirpt.mistakesFound == 1)
            {
                canvas.SetActive(false);
                DOTween.To(() => camera_.GetComponent<Camera>().orthographicSize, x => camera_.GetComponent<Camera>().orthographicSize = x, 20f, 1.5f).SetEase(Ease.InOutCubic)
                .OnComplete(() => getOut());
            }
        }
    }
    private void getOut() {
        PlayerPrefs.SetInt("currentText", 12);
        SceneManager.LoadScene(1);
    }
}
