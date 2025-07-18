using UnityEngine;
using UnityEngine.SceneManagement;

public class logicScript : MonoBehaviour
{
    [SerializeField] int sceneIndex;
    public void startGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
