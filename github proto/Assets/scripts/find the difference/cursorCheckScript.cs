using UnityEngine;

public class cursorCheckScript : MonoBehaviour
{
    public GameObject draggedObject = null;
    [SerializeField] private controlScript controlScript;
    [SerializeField] private string direction;
    [SerializeField] private GameObject rightButton, leftButton;

}