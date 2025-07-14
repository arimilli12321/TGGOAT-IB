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
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButton(0) && (cursorCheckScript.draggedObject == null || cursorCheckScript.draggedObject == gameObject))
        {
            following = true;
            if (cursorCheckScript.draggedObject == null) cursorCheckScript.draggedObject = gameObject;
        }
        else if (!Input.GetMouseButton(0))
        {
            following = false;
            cursorCheckScript.draggedObject = null;
        }
    }
}

