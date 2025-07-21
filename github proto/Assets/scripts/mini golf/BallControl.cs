using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class BallControl : MonoBehaviour
{
    [SerializeField] public Camera mainCamera;
    private float z;
    private int rotateAmount = 270;
    public bool showDirection = true;
    private bool isForward = false;
    public int shots = 5;
    [SerializeField] public TMP_Text shotsText;
    [SerializeField] private TMP_Text tutorialText;
    [SerializeField] private GameObject loseUI, winUi;
    private soundManagerScript soundManager;
    [SerializeField] private GameObject camera_;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("soundManager").Length == 2)
        {
            foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("soundManager"))
            {
                if (gameObj.transform.position.y == 0) Destroy(gameObj);
            }
        }
        soundManager = GameObject.FindGameObjectWithTag("soundManager").GetComponent<soundManagerScript>();
        soundManager.playMusicClip(2);
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && !isForward)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            while (transform.rotation != Quaternion.Euler(0, 0, 0))
                transform.Find("power 1").position = transform.Find("power 1").position * -1;
            transform.Find("power 1").localPosition = new Vector3(transform.Find("power 1").localPosition.x, transform.Find("power 1").localPosition.y + 3.1f, -2);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            while (transform.rotation != Quaternion.Euler(0, 0, 0))
                transform.Find("power 2").position = transform.Find("power 2").position * -1;
            transform.Find("power 2").localPosition = new Vector3(transform.Find("power 2").localPosition.x, transform.Find("power 2").localPosition.y + 6.35f, -2);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            while (transform.rotation != Quaternion.Euler(0, 0, 0))
                transform.Find("power 3").position = transform.Find("power 3").position * -1;
            transform.Find("power 3").localPosition = new Vector3(transform.Find("power 3").localPosition.x, transform.Find("power 3").localPosition.y + 9.65f, -2);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            while (transform.rotation != Quaternion.Euler(0, 0, 0))
                transform.Find("power sprite").position = transform.Find("power sprite").position * -1;
            transform.Find("power sprite").localPosition = new Vector3(transform.Find("power sprite").localPosition.x, transform.Find("power sprite").localPosition.y + 6.4f, -2);
            transform.Find("power sprite").localRotation = quaternion.identity;
            transform.Find("direction sprite").GetComponent<SpriteRenderer>().enabled = false;
            showDirection = false;
            rotateAmount = 90;
            isForward = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            while (transform.rotation != Quaternion.Euler(0, 0, 0))
                transform.Find("power 1").position = transform.Find("power 1").position * -1;
            transform.Find("power 1").localPosition = new Vector3(transform.Find("power 1").localPosition.x, transform.Find("power 1").localPosition.y - 3.1f, -2);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            while (transform.rotation != Quaternion.Euler(0, 0, 0))
                transform.Find("power 2").position = transform.Find("power 2").position * -1;
            transform.Find("power 2").localPosition = new Vector3(transform.Find("power 2").localPosition.x, transform.Find("power 2").localPosition.y - 6.35f, -2);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            while (transform.rotation != Quaternion.Euler(0, 0, 0))
                transform.Find("power 3").position = transform.Find("power 3").position * -1;
            transform.Find("power 3").localPosition = new Vector3(transform.Find("power 3").localPosition.x, transform.Find("power 3").localPosition.y - 9.65f, -2);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            while (transform.rotation != Quaternion.Euler(0, 0, 0))
                transform.Find("power sprite").position = transform.Find("power sprite").position * -1;
            transform.Find("power sprite").localPosition = new Vector3(transform.Find("power sprite").localPosition.x, transform.Find("power sprite").localPosition.y - 6.4f, -2);
            transform.Find("power sprite").localRotation = new Quaternion(0, 0, 180, 0);
            transform.Find("direction sprite").GetComponent<SpriteRenderer>().enabled = true;
            showDirection = true;
            rotateAmount = 270;
            isForward = false;
        }

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        Vector3 direction = worldMousePosition - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - rotateAmount);

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("hole"))
        {
            lose();
        }
        else if (collider.CompareTag("Finish"))
        {
            win();
        }
        else
        {
            int random = UnityEngine.Random.Range(1, 4);
            if (random == 1) soundManager.playSfxClip(0);
            if (random == 2) soundManager.playSfxClip(1);
            if (random == 3) soundManager.playSfxClip(2);
            z = transform.rotation.eulerAngles.z;
            if (collider.name.Equals("x Wall")) transform.rotation = Quaternion.Inverse(transform.rotation);
            else transform.rotation = Quaternion.Euler(0, 0, 180 - z);
        }
    }

    public void lose()
    {
        soundManager.playSfxClip(6);
        soundManager.transform.position = new Vector3(0, 0.1f, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void win()
    {
        tutorialText.text = " ";
        shotsText.text = " ";
        transform.Find("power 1").gameObject.SetActive(false);
        transform.Find("power 2").gameObject.SetActive(false);
        transform.Find("power 3").gameObject.SetActive(false);
        DOTween.To(() => camera_.GetComponent<Camera>().orthographicSize, x => camera_.GetComponent<Camera>().orthographicSize = x, 20f, 1.5f).SetEase(Ease.InOutCubic)
        .OnComplete(() => loadCutscene());
    }

    private void loadCutscene() {
        PlayerPrefs.SetInt("currentText", 19);
        SceneManager.LoadScene(1);
    }
}
