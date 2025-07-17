using DG.Tweening;
using UnityEngine;

public class controlScript : MonoBehaviour
{
    public int score = 0;
    public bool moving = false;
    [SerializeField] private GameObject camera_;
    public string canGo = "right";

    public void moveRight()
    {
        camera_.transform.DOMove(new Vector3(22, 8.5f, -10), 3f).SetEase(Ease.InOutCubic).OnComplete(() => movingfalse());
        transform.position = new Vector3(20.5f, 8.5f, transform.position.z);
        moving = true;
        canGo = "left"; 
    }
    public void moveLeft()
    {
        camera_.transform.DOMove(new Vector3(0, 0, -10), 3f).SetEase(Ease.InOutCubic).OnComplete(() => movingfalse());
        transform.position = new Vector3(0, 0, transform.position.z);
        moving = true;
        canGo = "right";
    }

    void movingfalse()
    {
        moving = false;
    }
}