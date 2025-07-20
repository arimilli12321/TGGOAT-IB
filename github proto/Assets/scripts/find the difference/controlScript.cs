using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class controlScript : MonoBehaviour
{
    private Vector3 mouseScreenPos;
    public int score = 0;
    public bool moving = false;
    [SerializeField] private GameObject camera_;

    public void Update()
    {
        mouseScreenPos = Mouse.current.position.ReadValue();
        mouseScreenPos.z = mouseScreenPos.z = Camera.main.nearClipPlane + 1;
    }
    public void move()
    {
        camera_.transform.DOMove(mouseScreenPos, 3f).SetEase(Ease.InOutCubic).OnComplete(() => movingfalse());
        transform.position = mouseScreenPos;
        moving = true;
    }

    public void OnMouseDown()
    {
        move();
        moving = false;
    }

    void movingfalse()
    {
        moving = false;
    }
}