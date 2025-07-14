using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class ShapeSorting : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private bool following = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            following = true;
        }
        if (following == true)
        {
            gameObject.transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition);;
        }
    }
}
