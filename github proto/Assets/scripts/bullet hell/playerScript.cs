using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections.Generic;
public class playerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 mouseScreenPos;
    [SerializeField] private GameObject loseText, winText, loseButton;
    [SerializeField] private Transform shields;
    [SerializeField] private GameObject Slider;
    public int sliderValue, sliderMaxValue;
    [SerializeField] private List<Sprite> sliderSprites;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mouseScreenPos = Mouse.current.position.ReadValue();
        mouseScreenPos.z = Camera.main.nearClipPlane + 1;
        transform.position = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        if (transform.position.x > 6.5) transform.position = new Vector3(6.5f, transform.position.y, transform.position.z);
        else if (transform.position.x < -6.5) transform.position = new Vector3(-6.5f, transform.position.y, transform.position.z);
        if (transform.position.y > 4.7) transform.position = new Vector3(transform.position.x, 4.7f, transform.position.z);
        else if (transform.position.y < -4.7) transform.position = new Vector3(transform.position.x, -4.7f, transform.position.z);
        shields.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("attack"))
        {
            foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("attack"))
            {
                Destroy(gameObj);
            }
            foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("enemy"))
            {
                Destroy(gameObj);
            }
            Destroy(shields.gameObject);
            loseText.SetActive(true);
            loseButton.SetActive(true);
            if (sliderValue == sliderMaxValue) winText.SetActive(false);
            GameObject.FindGameObjectWithTag("spawner").SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void changeSliderValue()
    {
        Slider.GetComponent<SpriteRenderer>().sprite = sliderSprites[sliderValue];
    }
}