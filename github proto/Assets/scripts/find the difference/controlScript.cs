using DG.Tweening;
using UnityEngine;

public class controlScript : MonoBehaviour
{
    public bool moving = false;
    [SerializeField] private GameObject camera_;
    public string canGo = "right";

    public void moveRight()
    {
        camera_.transform.DOMoveX(25, 3f).SetEase(Ease.InOutCubic).OnComplete(() => movingfalse());
        transform.position = new Vector3(25, transform.position.y, transform.position.z);
        moving = true;
        canGo = "left"; 
    }
    public void moveLeft()
    {
        camera_.transform.DOMoveX(0, 3f).SetEase(Ease.InOutCubic).OnComplete(() => movingfalse());
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
        moving = true;
        canGo = "right";
    }

    void movingfalse()
    {
        moving = false;
    }
}