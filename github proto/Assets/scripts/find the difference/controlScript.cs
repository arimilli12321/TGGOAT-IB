using System;
using DG.Tweening;
using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class controlScript : MonoBehaviour
{
    [SerializeField] float toplimit;
    [SerializeField] float bottomlimit;
    [SerializeField] float rightlimit;
    [SerializeField] float leftlimit;
    private Vector3 mouseScreenPos;
    public int score = 0;
    public bool moving = false;
    [SerializeField] private GameObject camera_;
    public bool zoomed = false;
    private soundManagerScript soundManager;

    void Start()
    {
        DOTween.SetTweensCapacity(5000, 5000);
        camera_.GetComponent<Camera>().orthographicSize = 1;
        DOTween.To(() => camera_.GetComponent<Camera>().orthographicSize, x => camera_.GetComponent<Camera>().orthographicSize = x, 20f, 1.5f).SetEase(Ease.InOutCubic);
        soundManager = GameObject.FindGameObjectWithTag("soundManager").GetComponent<soundManagerScript>();
        soundManager.playMusicClip(2);
    }

    public void Update()
    {
        mouseScreenPos = Mouse.current.position.ReadValue();
        mouseScreenPos.z = Camera.main.nearClipPlane + 0;
        if (Input.GetMouseButtonDown(1))
        {
            move();
            moving = false;
            zoomed = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            camera_.transform.DOMove(new Vector3(0, 0, -10), 1.5f).SetEase(Ease.InOutCubic).OnComplete(() => movingfalse());
            DOTween.To(() => camera_.GetComponent<Camera>().orthographicSize, x => camera_.GetComponent<Camera>().orthographicSize = x, 20f, 1.5f).SetEase(Ease.InOutCubic);
            transform.position = new Vector3(0, 0, -10);
            moving = true;
            zoomed = false;
        }
        if (score == 1)
        {
            if (camera_.GetComponent<Camera>().orthographicSize == 20)
            DOTween.To(() => camera_.GetComponent<Camera>().orthographicSize, x => camera_.GetComponent<Camera>().orthographicSize = x, 1f, 1f).SetEase(Ease.InOutCubic).OnComplete(() => cutscene());
        }
    }
    void cutscene()
    {
        PlayerPrefs.SetInt("currentText", 6);
        PlayerPrefs.SetFloat("cutsceneCamSize", 0.5f);
        SceneManager.LoadScene(1); 
    }
    public void move()
    {
        if (zoomed == false)
        {
            camera_.transform.DOMove(Camera.main.ScreenToWorldPoint(mouseScreenPos), 1.5f).SetEase(Ease.InOutCubic).OnComplete(() => movingfalse());
            DOTween.To(() => camera_.GetComponent<Camera>().orthographicSize, x => camera_.GetComponent<Camera>().orthographicSize = x, 7.5f, 1.5f).SetEase(Ease.InOutCubic);
            transform.position = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            moving = true;
        }
    }



    void movingfalse()
    {
        moving = false;
    }
}