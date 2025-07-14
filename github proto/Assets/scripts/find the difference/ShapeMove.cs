using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShapeSorting : MonoBehaviour
{
    [SerializeField] GameObject Big;
    [SerializeField] GameObject Small_corners;
    [SerializeField] GameObject Long_medium;
    [SerializeField] GameObject Big_Vertical;
    private Vector3 mouseScreenPos;
    private bool canfollow = true;
    private bool following = false;
    [SerializeField] private cursorCheckScript cursorCheckScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (following)
        {
            mouseScreenPos = Mouse.current.position.ReadValue();
            mouseScreenPos.z = Camera.main.nearClipPlane + 1;
            transform.position = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            transform.position = new Vector3(transform.position.x, transform.position.y, -2);
        }
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButton(0) && (cursorCheckScript.draggedObject == null || cursorCheckScript.draggedObject == gameObject))
        {
            if (canfollow == true)
            {
                following = true;
                if (cursorCheckScript.draggedObject == null) cursorCheckScript.draggedObject = gameObject;
            }
        }
        else if (!Input.GetMouseButton(0))
        {
            following = false;
            cursorCheckScript.draggedObject = null;
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name == "BigCollider")
        {
            if (gameObject.name == "Big")
            {
                if (following == false)
                {
                    if (canfollow == true)
                    {
                        canfollow = false;
                        Big.transform.position = new Vector3(-3.175f, 2.35f, -1);
                    }
                }
            }
        }
        if (collider.gameObject.name == "LongMediumCollider")
        {
            if (gameObject.name == "Long medium")
            {
                if (following == false)
                {
                    if (canfollow == true)
                    {
                        canfollow = false;
                        Long_medium.transform.position = new Vector3(-3.98f, -3.475f, -1);
                    }
                }
            }
        }
        if (collider.gameObject.name == "Smallcornerscollider")
        {
            if (gameObject.name == "Smallcorners")
            {
                if (following == false)
                {
                    if (canfollow == true)
                    {
                        canfollow = false;
                        Small_corners.transform.position = new Vector3(-1.945f, -1.025f, -1);
                    }
                }
            }
        }
        if (collider.gameObject.name == "VerticalCollider")
        {
            if (gameObject.name == "Big vertical")
            {
                if (following == false)
                {
                    if (canfollow == true)
                    {
                        canfollow = false;
                        Big_Vertical.transform.position = new Vector3(1.95f, -2.255f, -1);
                    }
                }
            }
        }
    }
}

