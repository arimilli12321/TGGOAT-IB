using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour
{
    [SerializeField] public Camera mainCamera;
    private float z;
    private int rotateAmount = 270;
    public bool showDirection = true;
    private bool isForward = false;
    public int shots = 5;


    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && !isForward)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            while (transform.rotation != Quaternion.Euler(0, 0, 0))
            transform.Find("power 1").position = transform.Find("power 1").position * -1;
            transform.Find("power 1").localPosition = new Vector3(transform.Find("power 1").localPosition.x, transform.Find("power 1").localPosition.y + 3, -2);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            while (transform.rotation != Quaternion.Euler(0, 0, 0))
            transform.Find("power 2").position = transform.Find("power 2").position * -1;
            transform.Find("power 2").localPosition = new Vector3(transform.Find("power 2").localPosition.x, transform.Find("power 2").localPosition.y + 6, -2);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            while (transform.rotation != Quaternion.Euler(0, 0, 0))
            transform.Find("power 3").position = transform.Find("power 3").position * -1;
            transform.Find("power 3").localPosition = new Vector3(transform.Find("power 3").localPosition.x, transform.Find("power 3").localPosition.y + 9, -2);
            transform.Find("direction sprite").GetComponent<SpriteRenderer>().enabled = false;
            showDirection = false;
            rotateAmount = 90;
            isForward = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            while (transform.rotation != Quaternion.Euler(0, 0, 0))
            transform.Find("power 1").position = transform.Find("power 1").position * -1;
            transform.Find("power 1").localPosition = new Vector3(transform.Find("power 1").localPosition.x, transform.Find("power 1").localPosition.y - 3, -2);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            while (transform.rotation != Quaternion.Euler(0, 0, 0))
            transform.Find("power 2").position = transform.Find("power 2").position * -1;
            transform.Find("power 2").localPosition = new Vector3(transform.Find("power 2").localPosition.x, transform.Find("power 2").localPosition.y - 6, -2);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            while (transform.rotation != Quaternion.Euler(0, 0, 0))
            transform.Find("power 3").position = transform.Find("power 3").position * -1;
            transform.Find("power 3").localPosition = new Vector3(transform.Find("power 3").localPosition.x, transform.Find("power 3").localPosition.y - 9, -2);
            transform.Find("direction sprite").GetComponent<SpriteRenderer>().enabled = true;
            showDirection = true;
            rotateAmount = 270;
            isForward = false;
        }

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        Vector3 direction = worldMousePosition - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - rotateAmount);

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("hole"))
        {
            transform.Find("power 1").GetComponent<powerScript>().lose();
        }
        else
        {
            z = transform.rotation.eulerAngles.z;
            if (collider.name.Equals("x Wall")) transform.rotation = Quaternion.Inverse(transform.rotation);
            else transform.rotation = Quaternion.Euler(0, 0, 180 - z);
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
