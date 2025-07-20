using UnityEngine;

public class enterButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject objectToEnter;
    private soundManagerScript soundManager;

    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("soundManager").GetComponent<soundManagerScript>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (transform.Find("return sprite") == null) soundManager.playSfxClip(9);
            else soundManager.playSfxClip(8);
            objectToEnter.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
