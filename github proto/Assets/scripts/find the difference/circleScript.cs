using UnityEngine;

public class circleScript : MonoBehaviour
{
    Color green2 = new Color(0.1003026f, 0.9245283f, 0.1669887f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("Incorrect").GetComponent<SpriteRenderer>().color = green2;
        }
    }
}


