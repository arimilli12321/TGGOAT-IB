using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShapeSorting : MonoBehaviour
{
    private Vector3 mouseScreenPos;
    private bool following = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseScreenPos = Mouse.current.position.ReadValue();
        mouseScreenPos.z = Camera.main.nearClipPlane + 1;
        if (Input.GetMouseButton(0))
        {
            following = true;
        }
        if (following == true)
        {
            transform.position = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        }
    }
}
