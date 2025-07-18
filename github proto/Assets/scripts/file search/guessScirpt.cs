using UnityEngine;

public class guessScirpt : MonoBehaviour
{
    public bool isGuessing = false;
    public int mistakesFound = 0;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && !isGuessing)
        {
            isGuessing = true;
        }
        else if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && isGuessing)
        {
            isGuessing = false;
        }
    }
}
