using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class ShapeSorting : MonoBehaviour
{
    [SerializeField] controlScript controls;
    [SerializeField] GameObject Big;
    [SerializeField] GameObject Small_corners;
    [SerializeField] GameObject Long_medium;
    [SerializeField] GameObject Big_Vertical;
    [SerializeField] GameObject Thin_long;
    [SerializeField] GameObject Long_small;
    private Vector3 mouseScreenPos;
    private bool canfollow = true;
    private bool following = false;
    [SerializeField] private cursorCheckScript cursorCheckScript;
    [SerializeField] private GameObject camera_;
    private soundManagerScript soundManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("soundManager").GetComponent<soundManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (following)
        {
            mouseScreenPos = Mouse.current.position.ReadValue();
            mouseScreenPos.z = Camera.main.nearClipPlane + 1;
            transform.position = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
            if (!controls.zoomed)
            {
                if (transform.position.x > 35.5) transform.position = new Vector3(35.5f, transform.position.y, transform.position.z);
                else if (transform.position.x < -35.5) transform.position = new Vector3(-35.5f, transform.position.y, transform.position.z);
                if (transform.position.y > 20) transform.position = new Vector3(transform.position.x, 20, transform.position.z);
                else if (transform.position.y < -20) transform.position = new Vector3(transform.position.x, -20, transform.position.z);
            }
            else
            {
                float x = transform.position.x;
                float y = transform.position.y;
                float z = transform.position.z;
                if (x > 13 + camera_.transform.position.x) transform.position = new Vector3(13 + camera_.transform.position.x, transform.position.y, z);
                else if (x < -13 + camera_.transform.position.x) transform.position = new Vector3(-13f + camera_.transform.position.x, transform.position.y, z);
                if (y > 7.5 + camera_.transform.position.y) transform.position = new Vector3(transform.position.x, 7.5f + camera_.transform.position.y, z);
                else if (y < -7.5 + camera_.transform.position.y) transform.position = new Vector3(transform.position.x, -7.5f + camera_.transform.position.y, z);
            }
        }
    }

    void OnMouseOver()
    {
            if (Input.GetMouseButton(0) && (cursorCheckScript.draggedObject == null || cursorCheckScript.draggedObject == gameObject))
            {
                if (canfollow == true)
                {
                    if (!following) soundManager.playSfxClip(11);
                    following = true;
                    if (cursorCheckScript.draggedObject == null) cursorCheckScript.draggedObject = gameObject;
                }
            }
            else if (!Input.GetMouseButton(0))
            {
                following = false;
                cursorCheckScript.draggedObject = null;
                transform.position = new Vector3(transform.position.x, transform.position.y, -4);
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
                        Big.transform.position = new Vector3(-3.484f, 2.765f, -2);
                        controls.score += 1;
                        soundManager.playSfxClip(12);
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
                        Long_medium.transform.position = new Vector3(-4.289f, -3.121f, -2);
                        controls.score += 1;
                        soundManager.playSfxClip(12);
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
                        Small_corners.transform.position = new Vector3(-2.254f, -0.671f, -2);
                        controls.score += 1;
                        soundManager.playSfxClip(12);
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
                        Big_Vertical.transform.position = new Vector3(1.641f, -1.901f, -2);
                        controls.score += 1;
                        soundManager.playSfxClip(12);
                    }
                }
            }
        }
        if (collider.gameObject.name == "LongCollider")
        {
            if (gameObject.name == "Long thin")
            {
                if (following == false)
                {
                    if (canfollow == true)
                    {
                        canfollow = false;
                        Thin_long.transform.position = new Vector3(2.451f, 0.974f, -2);
                        controls.score += 1;
                        soundManager.playSfxClip(12);
                    }
                }
            }
        }
        if (collider.gameObject.name == "LongSmallCollider")
        {
            if (gameObject.name == "long small")
            {
                if (following == false)
                {
                    if (canfollow == true)
                    {
                        canfollow = false;
                        Long_small.transform.position = new Vector3(1.2f, 3.904f, -2);
                        controls.score += 1;
                        soundManager.playSfxClip(12);
                    }
                }
            }
        }
        if (collider.gameObject.name == "LongThinCollider")
        {
            if (gameObject.name == "Long thin")
            {
                if (canfollow == true)
                {
                    if (following == false)
                    {
                        canfollow = false;
                        Thin_long.transform.position = new Vector3(2.456f, 0.954f, -2);
                        controls.score += 1;
                        soundManager.playSfxClip(12);
                    }
                }
            }
        }
        if (collider.gameObject.name == "NCC1")
        {
            if (gameObject.name == "No corners")
            {
                if (canfollow == true)
                {
                    if (following == false)
                    {
                        canfollow = false;
                        gameObject.transform.position = new Vector3(-0.85f, -3.021f, -2);
                        controls.score += 1;
                        collider.enabled = false;
                        soundManager.playSfxClip(12);
                    }
                }
            }
        }
        if (collider.gameObject.name == "NCC2")
        {
            if (gameObject.name == "No corners")
            {
                if (canfollow == true)
                {
                    if (following == false)
                    {
                        canfollow = false;
                        gameObject.transform.position = new Vector3(4.386f, -2.938f, -2);
                        controls.score += 1;
                        collider.enabled = false;
                        soundManager.playSfxClip(12);
                    }
                }
            }
        }
        if (collider.gameObject.name == "NCC4")
        {
            if (gameObject.name == "No corners")
            {
                if (canfollow == true)
                {
                    if (following == false)
                    {
                        canfollow = false;
                        gameObject.transform.position = new Vector3(3.341f, 3.894f, -2);
                        controls.score += 1;
                        collider.enabled = false;
                        soundManager.playSfxClip(12);
                    }
                }
            }
        }
        if (collider.gameObject.name == "NCC3")
        {
            if (gameObject.name == "No corners")
            {
                if (canfollow == true)
                {
                    if (following == false)
                    {
                        canfollow = false;
                        gameObject.transform.position = new Vector3(4.849f, 3.929f, -2);
                        controls.score += 1;
                        collider.enabled = false;
                        soundManager.playSfxClip(12);
                    }
                }
            }
        }
    }
}
