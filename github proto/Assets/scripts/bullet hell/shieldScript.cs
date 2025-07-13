using UnityEngine;
using UnityEngine.UI;

public class shieldScript : MonoBehaviour
{
    private float regenerateCooldown = 0;
    [SerializeField] private SpriteRenderer disabledSprite;
    [SerializeField] private Transform player;
    [SerializeField] public Slider slider;
    [SerializeField] private GameObject winText;
    [SerializeField] private spawnerScript spawnerScript;
    void Update()
    {
        transform.RotateAround(player.position, Vector3.forward, -150f * Time.deltaTime);
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
            regenerateCooldown = 3f;
            slider.value += 1;
            spawnerScript.enemyCount--;
            if (slider.value == slider.maxValue)
            {
                foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("attack"))
                {
                    Destroy(gameObj);
                }
                foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("enemy"))
                {
                    Destroy(gameObj);
                }
                player.gameObject.SetActive(false);
                slider.gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("spawner").SetActive(false);
                winText.SetActive(true);
                transform.parent.gameObject.SetActive(false);
            }
            transform.Find("sprite").GetComponent<SpriteRenderer>().enabled = false;
            disabledSprite.gameObject.SetActive(true);
        }
    }
}
