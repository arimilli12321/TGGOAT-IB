using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class shieldScript : MonoBehaviour
{
    public float regenerateCooldown = 0;
    [SerializeField] private SpriteRenderer disabledSprite;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject winText;
    [SerializeField] private spawnerScript spawnerScript;
    private soundManagerScript soundManager;

    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("soundManager").GetComponent<soundManagerScript>();
    }

    void Update()
    {
        transform.RotateAround(player.transform.position, Vector3.forward, -150f * Time.deltaTime);
        if (regenerateCooldown > 0) regenerateCooldown -= Time.deltaTime;
        if (regenerateCooldown <= 0)
        {
            regenerateCooldown = 0;
            transform.Find("sprite").GetComponent<SpriteRenderer>().enabled = true;
            disabledSprite.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("enemy") && regenerateCooldown == 0)
        {
            Destroy(collider.gameObject);
            regenerateCooldown = 2.5f;
            player.GetComponent<playerScript>().sliderValue += 1;
            player.GetComponent<playerScript>().changeSliderValue();
            spawnerScript.enemyCount--;
            soundManager.playSfxClip(7);
            if (player.GetComponent<playerScript>().sliderValue == player.GetComponent<playerScript>().sliderMaxValue)
            {
                PlayerPrefs.SetInt("currentText", 15);
                SceneManager.LoadScene(1);
            }
            transform.Find("sprite").GetComponent<SpriteRenderer>().enabled = false;
            disabledSprite.gameObject.SetActive(true);
        }
    }
}
