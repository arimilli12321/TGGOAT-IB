using UnityEngine;
using UnityEngine.UI;

public class shieldScript : MonoBehaviour
{
    private float regenerateCooldown = 0;
    [SerializeField] private SpriteRenderer disabledSprite;
    [SerializeField] private Transform player;
    [SerializeField] public Slider slider;
    [SerializeField] private GameObject winText;
    void Update()
    {
        transform.RotateAround(player.position, Vector3.forward, -120f * Time.deltaTime);
        if (regenerateCooldown > 0) regenerateCooldown -= Time.deltaTime;
        if (regenerateCooldown <= 0)
        {
            regenerateCooldown = 0;
            GetComponent<SpriteRenderer>().enabled = true;
            disabledSprite.color = new Color(0, 0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("enemy") && regenerateCooldown == 0)
        {
            Destroy(collider.gameObject);
            regenerateCooldown = 3f;
            slider.value += 1;
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
                winText.SetActive(true);
                transform.parent.gameObject.SetActive(false);
            }
            GetComponent<SpriteRenderer>().enabled = false;
            disabledSprite.color = new Color(0, 0, 0, 100);
        }
    }
}
