using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class powerScript : MonoBehaviour
{
    [SerializeField] private float power;
    [SerializeField] private GameObject ball;
    private float timer = 0;
    private bool clicked = false;
    [SerializeField] private TMP_Text shotsText;
    [SerializeField] private GameObject loseText;

    void Update()
    {
        if (timer < 1.5f && clicked)
        {
            if (ball.GetComponent<BallControl>().enabled) ball.GetComponent<BallControl>().enabled = false;
            if (ball.transform.Find("power 1").GetComponent<SpriteRenderer>().enabled)
            {
                ball.transform.Find("power 1").GetComponent<SpriteRenderer>().enabled = false;
            }
            if (ball.transform.Find("power 2").GetComponent<SpriteRenderer>().enabled)
            {
                ball.transform.Find("power 2").GetComponent<SpriteRenderer>().enabled = false;
            }
            if (ball.transform.Find("power 3").GetComponent<SpriteRenderer>().enabled)
            {
                ball.transform.Find("power 3").GetComponent<SpriteRenderer>().enabled = false;
            }
            if (ball.transform.Find("direction sprite").GetComponent<SpriteRenderer>().enabled)
            {
                ball.transform.Find("direction sprite").GetComponent<SpriteRenderer>().enabled = false;
            }
            ball.transform.position += ball.transform.up * power * Time.deltaTime;
            timer += Time.deltaTime;
        }
        else if (timer >= 1.5f && timer < 1.7f)
        {
            timer += Time.deltaTime;
        }
        else if (timer >= 1.7f)
        {
            ball.GetComponent<BallControl>().enabled = true;
            ball.transform.Find("power 1").GetComponent<SpriteRenderer>().enabled = true;
            ball.transform.Find("power 2").GetComponent<SpriteRenderer>().enabled = true;
            ball.transform.Find("power 3").GetComponent<SpriteRenderer>().enabled = true;
            if (ball.GetComponent<BallControl>().showDirection)
            {
                ball.transform.Find("direction sprite").GetComponent<SpriteRenderer>().enabled = true;
            }
            timer = 0;
            clicked = false;
            ball.GetComponent<BallControl>().shots--;
            shotsText.text = $"{ball.GetComponent<BallControl>().shots} shots left";
            if (ball.GetComponent<BallControl>().shots == 0)
            {
                lose();
            }
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!clicked)
            {
                clicked = true;
            }
        }
    }

    public void lose()
    {
        foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("hole")) Destroy(gameObj);
        shotsText.gameObject.SetActive(false);
        loseText.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
