using Unity.Mathematics;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] public Camera mainCamera;
    private float z;

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        Vector3 direction = worldMousePosition - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 270);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        z = transform.rotation.eulerAngles.z;
        if (collider.name.Equals("x Wall")) transform.rotation = Quaternion.Inverse(transform.rotation);
        else transform.rotation = Quaternion.Euler(0, 0, 180 - z);
    }
}
