using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.TextCore.Text;

public class textScript : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private List<string> texts = new List<string>();
    private int currentText = 0;
    private int currentVisibleCharIndex;
    private Coroutine typeWriterCoroutine_;
    private bool isExpanding = false;
    private char character;
    [SerializeField] private GameObject textBox, background;
    private GameObject soundManager;

    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("soundManager");
        soundManager.GetComponent<soundManagerScript>().playMusicClip(1);
        currentText = PlayerPrefs.GetInt("currentText");
        changeText(texts[currentText]);
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
                if (texts[currentText + 1].Equals("1"))
                {
                    textBox.SetActive(false);
                    background.transform.DOScale(new Vector3(4, 4, 1), 1f).SetEase(Ease.InOutCubic).OnComplete(() =>
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
                    background.transform.DOScale(new Vector3(4, 4, 1), 1f).SetEase(Ease.InOutCubic).OnComplete(() =>
                    {
                        SceneManager.LoadScene(4);
                    });             
                }
                else if (texts[currentText + 1].Equals("4"))
                {
                    textBox.SetActive(false);
                    background.transform.DOScale(new Vector3(4, 4, 1), 1f).SetEase(Ease.InOutCubic).OnComplete(() =>
                    {
                        SceneManager.LoadScene(5);
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
