using UnityEngine;

public class wrongWordsScript : MonoBehaviour
{
    [SerializeField] private guessScirpt guessScirpt;
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (guessScirpt.isGuessing)
            {
                transform.Find("right sprite").gameObject.SetActive(true);
                guessScirpt.mistakesFound++;
                if (guessScirpt.mistakesFound == 2)
                {
                    // winning yipee
                }
            }
        }
    }
}
