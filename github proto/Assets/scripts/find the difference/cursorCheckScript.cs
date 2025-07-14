using UnityEngine;

public class cursorCheckScript : MonoBehaviour
{
    public GameObject draggedObject = null;
    [SerializeField] private controlScript controlScript;
    [SerializeField] private string direction;
    [SerializeField] private GameObject rightButton, leftButton;

    void OnMouseOver () {
        if (controlScript.canGo.Equals(direction)) {
            if (direction.Equals("right"))
            {
                if (controlScript.moving == false)
                {
                    controlScript.moveRight();                    
                }
            }
            else if (controlScript.moving == false)
                {
                    controlScript.moveLeft();                    
                }
        }
    }

    void OnMouseExit() {
        if (direction.Equals("right")) rightButton.SetActive(false);
        else leftButton.SetActive(false);
    }
}
