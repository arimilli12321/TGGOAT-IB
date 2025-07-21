using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.TextCore.Text;

public class textScript : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] private TMP_Text text;
    [SerializeField] private List<string> texts = new List<string>();
    public int currentText = 0;
    private int currentVisibleCharIndex;
    private Coroutine typeWriterCoroutine_;
    private bool isExpanding = false;
    private char character;
    [SerializeField] private GameObject textBox, background;
    private GameObject soundManager;
    public float timer = 0;

    void Update()
    {
        if (currentText == 1)
        {
            text.color = Color.orange;
            text.outlineWidth = 0.15f;
        }
        else if (currentText == 6)
        {
            cam.GetComponent<Camera>().backgroundColor = new Color(0.227451f, 0.7803922f, 0.6156863f);
        }
        else if (currentText == 10)
        {
            cam.GetComponent<Camera>().backgroundColor = new Color(0.1607843f, 0.227451f, 0.3568628f);
        }
        else
        {
            text.color = Color.black;
            text.outlineWidth = 0;
        }
        if (timer > 0) timer -= Time.deltaTime;
        else if (timer != -1)
        {
            timer = -1;
            changeText(texts[currentText]);
        }
        
    }
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("soundManager");
        if (PlayerPrefs.GetFloat("cutsceneCamSize") != 0)
        {
            cam.GetComponent<Camera>().orthographicSize = PlayerPrefs.GetFloat("cutsceneCamSize");
            PlayerPrefs.SetFloat("cutsceneCamSize", 0);
            timer = 1f;
            DOTween.To(() => cam.GetComponent<Camera>().orthographicSize, x => cam.GetComponent<Camera>().orthographicSize = x, 5f, 1f).SetEase(Ease.InOutCubic);

        }
        soundManager.GetComponent<soundManagerScript>().playMusicClip(1);
        currentText = PlayerPrefs.GetInt("currentText");
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !isExpanding)
        {
            if (text.text != "")
            {
                text.text = "";
                currentText++;
                changeText(texts[currentText]);
                if (texts[currentText + 1] == "1")
                {
                    Debug.Log("done");
                    textBox.SetActive(false);
                    background.transform.DOScale(new Vector3(2f, 2f, 1), 1f).SetEase(Ease.InOutCubic).OnComplete(() =>
                    {
                        SceneManager.LoadScene(2);
                    });
                }
                else if (texts[currentText + 1].Equals("2"))
                {
                    textBox.SetActive(false);
                    background.transform.DOScale(new Vector3(4, 4, 1), 1f).SetEase(Ease.InOutCubic).OnComplete(() =>
                    {
                        SceneManager.LoadScene(3);
                    });
                }
                else if (texts[currentText + 1].Equals("3"))
                {
                    textBox.SetActive(false);
                    background.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.InOutCubic).OnComplete(() =>
                    {
                        SceneManager.LoadScene(5);
                    });
                }
                else if (texts[currentText + 1].Equals("4"))
                {
                    textBox.SetActive(false);
                    background.transform.DOScale(new Vector3(0.8f, 0.8f, 1), 1f).SetEase(Ease.InOutCubic).OnComplete(() =>
                    {
                        SceneManager.LoadScene(4);
                    });
                } 
                else if (texts[currentText + 1].Equals("5"))
                {
                    textBox.SetActive(false);
                    background.transform.DOScale(new Vector3(0.8f, 0.8f, 1), 1f).SetEase(Ease.InOutCubic).OnComplete(() =>
                    {
                        SceneManager.LoadScene(6);
                    });
                } 
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            StopCoroutine(typeWriterCoroutine_);
            text.maxVisibleCharacters = text.text.Length;
            isExpanding = false;
        }
    }

    private IEnumerator typeWriter()
    {
        TMP_TextInfo textinfo = text.textInfo;
        while (currentVisibleCharIndex < textinfo.characterCount + 1)
        {
            if (currentVisibleCharIndex < text.text.Length)
            {
                character = textinfo.characterInfo[currentVisibleCharIndex].character;
            }
            if (character.Equals('.')) yield return new WaitForSeconds(0.7f);
            else yield return new WaitForSeconds(1 / 30f);
            text.maxVisibleCharacters++;
            currentVisibleCharIndex++;
        }
        isExpanding = false;
    }

    private void changeText(string newText)
    {
        if (typeWriterCoroutine_ != null)
        {
            StopCoroutine(typeWriterCoroutine_);
        }
        text.text = newText;
        text.maxVisibleCharacters = 0;
        currentVisibleCharIndex = 0;
        isExpanding = true;
        typeWriterCoroutine_ = StartCoroutine(typeWriter());
    }
}
