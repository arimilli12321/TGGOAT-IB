using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class creditScript : MonoBehaviour
{
    [SerializeField] List<GameObject> credits = new List<GameObject>();
    int currentCredit = -1;
    private soundManagerScript soundManager;

    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("soundManager").GetComponent<soundManagerScript>();
        while (soundManager == null) {}
        soundManager.playMusicClip(1);
        moveIn();
    }

    private IEnumerator moveOut(Transform t) {
        yield return new WaitForSeconds(5f);
        t.DOMoveX(-800, 1).OnComplete(() => moveIn());
    }

    private void moveIn() {
        currentCredit++;
        if (currentCredit <= 3)
            credits[currentCredit].transform.DOMoveX(391.5f, 1).OnComplete(() => StartCoroutine(moveOut(credits[currentCredit].transform)));
    }
}
