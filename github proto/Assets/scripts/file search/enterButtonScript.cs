using UnityEngine;

public class enterButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject objectToEnter;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            objectToEnter.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
