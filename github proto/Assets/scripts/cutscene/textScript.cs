using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textScript : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private List<string> texts = new List<string>();
    private int currentText = 0;
    private int currentVisibleCharIndex;
    private Coroutine typeWriterCoroutine_;
    private bool isExpanding = false;

    void Start()
    {
        changeText(texts[currentText]);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !isExpanding)
        {
            if (text.text == "")
            {
                // code that runs when the last line of text is passed and the cutscene ends
            }
            else
            {
                text.text = "";
                currentText++;
                changeText(texts[currentText]);
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
                char character = textinfo.characterInfo[currentVisibleCharIndex].character;
            }
            text.maxVisibleCharacters++;
            yield return new WaitForSeconds(1 / 30f);
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
