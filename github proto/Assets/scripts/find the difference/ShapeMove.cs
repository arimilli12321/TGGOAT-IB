using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShapeSorting : MonoBehaviour
{
    [SerializeField] GameObject Big;
    [SerializeField] GameObject Small_corners;
    [SerializeField] GameObject Long_medium;
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
        }
        if (Big.transform.position.x >= -3.5f && Big.transform.position.x <= -2.5f)
        {
            canfollow = false;
            following = false;
        }
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && (cursorCheckScript.draggedObject == null || cursorCheckScript.draggedObject == gameObject))
        {
            if (canfollow == true)
            {
                following = true;
                if (cursorCheckScript.draggedObject == null) cursorCheckScript.draggedObject = gameObject;
            }
        }
    }
}

