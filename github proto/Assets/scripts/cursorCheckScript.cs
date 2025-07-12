using UnityEngine;

public class cursorCheckScript : MonoBehaviour
{
    [SerializeField] private controlScript controlScript;
    [SerializeField] private string direction;
    [SerializeField] private GameObject rightButton, leftButton;

    void OnMouseOver () {
        if (controlScript.canGo.Equals(direction)) {
            if (direction.Equals("right")) rightButton.SetActive(true);
            else leftButton.SetActive(true);
        }
    }
}
