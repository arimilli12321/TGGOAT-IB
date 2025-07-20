using UnityEngine;

public class enemyScript : MonoBehaviour
{
    private Transform player;
    [SerializeField] private GameObject attack;
    public float timer = 0f;
    [SerializeField] public int movement = 0;
    [SerializeField] public string direction_ = "none";
    [SerializeField] public Vector3 rotatePoint = Vector3.zero;
    public spawnerScript spawnerScript;
    private soundManagerScript soundManager;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        soundManager = GameObject.FindGameObjectWithTag("soundManager").GetComponent<soundManagerScript>();
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        switch (movement)
        {
            case 1:
                if (direction_.Equals("left"))
                {
                    transform.position += Vector3.left * 2f * Time.deltaTime;
                    if (transform.position.x <= -6.2) direction_ = "right";
                }
                else if (direction_.Equals("right"))
                {
                    transform.position += Vector3.right * 2f * Time.deltaTime;
                    if (transform.position.x >= 6.2) direction_ = "left";
                }
                else if (direction_.Equals("up"))
                {
                    transform.position += Vector3.up * 2f * Time.deltaTime;
                    if (transform.position.y >= 4.4) direction_ = "down";
                }
                else if (direction_.Equals("down"))
                {
                    transform.position += Vector3.down * 2f * Time.deltaTime;
                    if (transform.position.y <= -4.4) direction_ = "up";
                }
                break;
            case 2:
                if (direction_.Equals("clockwise")) transform.RotateAround(rotatePoint, Vector3.back, 90f * Time.deltaTime);
                else transform.RotateAround(rotatePoint, Vector3.forward, 90f * Time.deltaTime);
                break;
        }
        if (timer >= 1.5f + (spawnerScript.enemyCount / 10.0))
        {
            spawnAttack();
            timer = 0f;
        }
        timer += Time.deltaTime;
    }

    private void spawnAttack ()
    {
        int random = Random.Range(1, 3);
        if (random == 1) soundManager.playSfxClip(13);
        else soundManager.playSfxClip(14);
        GameObject newAttack = Instantiate(attack, transform.position, transform.rotation);
        newAttack.SetActive(true);
    }
}
