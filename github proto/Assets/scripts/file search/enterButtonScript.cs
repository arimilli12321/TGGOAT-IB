using UnityEngine;

public class enterButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject objectToEnter, folder1UI, folder2UI, folder3UI, folder4UI;
    private soundManagerScript soundManager;
    [SerializeField] private int uiState1, uiState2, uiState3, uiState4; 

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

            if (folder1UI != null && uiState1 == 1) folder1UI.SetActive(false);
            else if (folder1UI != null) folder1UI.SetActive(true);

            if (folder2UI != null && uiState2 == 1) folder2UI.SetActive(false);
            else if (folder2UI != null) folder2UI.SetActive(true);

            if (folder3UI != null && uiState3 == 1) folder3UI.SetActive(false);
            else if (folder3UI != null) folder3UI.SetActive(true);

            if (folder4UI != null && uiState4 == 1) folder4UI.SetActive(false);
            else if (folder4UI != null) folder4UI.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
