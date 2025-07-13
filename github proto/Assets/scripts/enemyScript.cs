using UnityEngine;

public class enemyScript : MonoBehaviour
{
    private Transform player;
    [SerializeField] private GameObject attack;
    private float timer = 0f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        if (timer >= 0.8f)
        {
            spawnAttack();
            timer = 0f;
        }
        timer += Time.deltaTime;
    }

    private void spawnAttack ()
    {
        GameObject newAttack = Instantiate(attack, transform.position, transform.rotation);
        newAttack.SetActive(true);
    }
}
