using DG.Tweening;
using UnityEngine;

public class controlScript : MonoBehaviour
{

    [SerializeField] private GameObject camera_;
    public string canGo = "right";

    public void moveRight()
    {
        camera_.transform.position = new Vector3(25, 0, -10);
        transform.position = new Vector3(25, transform.position.y, transform.position.z);
        canGo = "left";
    }
    public void moveLeft()
    {
        camera_.transform.position = new Vector3(0, 0, -10);
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
        canGo = "right";
    }
}