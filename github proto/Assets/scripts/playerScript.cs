using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
public class playerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject loseText, loseButton;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.linearVelocityY = 5f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.linearVelocityY = -5f;
        }
        else rb.linearVelocityY = 0;

        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocityX = -5f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocityX = 5f;
        }
        else rb.linearVelocityX = 0;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("attack"))
        {
            foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("attack"))
            {
                Destroy(gameObj);
            }
            loseText.SetActive(true);
            loseButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}