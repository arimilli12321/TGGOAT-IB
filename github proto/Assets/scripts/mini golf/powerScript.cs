using UnityEngine;

public class powerScript : MonoBehaviour
{
    [SerializeField] private float power;
    [SerializeField] private GameObject direction;

    void OnMouseOver()
    {
        if (power == 1)
        {
            direction.transform.position = new Vector3(0, 0.1f, -2) - direction.transform.parent.transform.position;
            direction.transform.localScale = new Vector3(0.75f, 2, 0);
        }
        else if (power == 2)
        {
            direction.transform.position = new Vector3(0, 0.2f, -1) - direction.transform.parent.transform.position;;
            direction.transform.localScale = new Vector3(0.75f, 4, 0);
        } 
        else if (power == 3)
        {
            direction.transform.position = new Vector3(0, 0.3f, -1) - direction.transform.parent.transform.position;;
            direction.transform.localScale = new Vector3(0.75f, 6, 0);
        } 
    } 
}
