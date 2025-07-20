using UnityEngine;

public class powerScript : MonoBehaviour
{
    [SerializeField] private float power;
    [SerializeField] private GameObject ball;
    private float timer = 0;
    private bool clicked = false;
    private soundManagerScript soundManager;

    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("soundManager").GetComponent<soundManagerScript>();
    }

    void Update()
    {
        if (timer < 1.5f && clicked)
        {
            if (ball.GetComponent<BallControl>().enabled) ball.GetComponent<BallControl>().enabled = false;
            if (ball.transform.Find("power sprite").GetComponent<SpriteRenderer>().enabled)
            {
                ball.transform.Find("power sprite").GetComponent<SpriteRenderer>().enabled = false;
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
            ball.transform.Find("power sprite").GetComponent<SpriteRenderer>().enabled = true;
            if (ball.GetComponent<BallControl>().showDirection)
            {
                ball.transform.Find("direction sprite").GetComponent<SpriteRenderer>().enabled = true;
            }
            timer = 0;
            clicked = false;
            ball.GetComponent<BallControl>().shots--;
            ball.GetComponent<BallControl>().shotsText.text = $"{ball.GetComponent<BallControl>().shots} shots left";
            if (ball.GetComponent<BallControl>().shots == 0)
            {
                ball.GetComponent<BallControl>().lose();
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
                if (power == 1) soundManager.playSfxClip(5);
                else if (power == 2) soundManager.playSfxClip(4);
                else if (power == 3) soundManager.playSfxClip(3);
            }
        }
    }
}
