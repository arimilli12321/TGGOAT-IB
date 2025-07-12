using DG.Tweening;
using UnityEngine;

public class controlScript : MonoBehaviour
{

    [SerializeField] private GameObject camera_;
    public string canGo = "right";

    public void moveRight()
    {
        camera_.transform.DOMoveX(25, 1, true);
    }
    public void moveLeft()
    {
        camera_.transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }
}