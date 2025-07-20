using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Numerics;

public class catScript : MonoBehaviour
{
    private float timer = 0;
    [SerializeField] private List<GameObject> objectsToDeactivate = new List<GameObject>();
    [SerializeField] private GameObject camera_;
    private Animator animator;
    private Coroutine animCoroutine;

    void Start()
    {
        DOTween.SetTweensCapacity(5000, 5000);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (timer < 0.5f) timer += Time.deltaTime;
        else
        {
            timer = 0;
            if (Random.Range(1, 3) == 1 && animCoroutine == null)
            {
                animCoroutine = StartCoroutine(startAnimation());
            }
        }
    }

    private IEnumerator startAnimation()
    {
        foreach (GameObject gameObj in objectsToDeactivate)
        {
            gameObj.SetActive(false);
        }
        camera_.GetComponent<Camera>().backgroundColor = Color.black;
        DOTween.To(() => camera_.GetComponent<Camera>().orthographicSize, x => camera_.GetComponent<Camera>().orthographicSize = x, 20f, 1f).SetEase(Ease.InOutCubic);
        yield return new WaitForSeconds(3f);
        animator.Play("catwake");
        yield return new WaitForSeconds(3.7f);
        animator.Play("catwalk");
        transform.parent.position = new UnityEngine.Vector3(-42, -15f, -1);
        transform.localScale = new UnityEngine.Vector3(2, 2, 1);
        transform.localPosition = new UnityEngine.Vector3(0, 0, -1);
        transform.parent.DOMoveX(23, 4);
    }

}
