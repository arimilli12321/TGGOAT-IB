using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public int enemyCount = 0;
    [SerializeField] float spawnRate = 1.5f;
    private float timer;
    [SerializeField] GameObject enemy;

    private void Start()
    {
        for (int i = 0; i < 3; i++) 
        {
            timer = 0;
            enemyCount++;
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-6, 7), Random.Range(-4, 5), 0), Quaternion.identity);
            newEnemy.SetActive(true);
            int enemyType = Random.Range(1, 4);
            if (enemyType == 1 || enemyType == 2)
            {
                newEnemy.GetComponent<enemyScript>().movement = 1;
                int newDirection = Random.Range(1, 5);
                if (newDirection == 1) newEnemy.GetComponent<enemyScript>().direction_ = "up";
                else if (newDirection == 2) newEnemy.GetComponent<enemyScript>().direction_ = "down";
                else if (newDirection == 3) newEnemy.GetComponent<enemyScript>().direction_ = "left";
                else if (newDirection == 4) newEnemy.GetComponent<enemyScript>().direction_ = "right";
            }
            else
            {
                newEnemy.GetComponent<enemyScript>().movement = 2;
                int newDirection = Random.Range(1, 5);
                if (newDirection == 1) newEnemy.GetComponent<enemyScript>().rotatePoint = Vector3.right * 2 + newEnemy.transform.position;
                else if (newDirection == 2) newEnemy.GetComponent<enemyScript>().rotatePoint = Vector3.left * 2 + newEnemy.transform.position;
                else if (newDirection == 3) newEnemy.GetComponent<enemyScript>().rotatePoint = Vector3.up * 2 + newEnemy.transform.position;
                else if (newDirection == 4) newEnemy.GetComponent<enemyScript>().rotatePoint = Vector3.down * 2 + newEnemy.transform.position;
                newDirection = Random.Range(1, 3);
                if (newDirection == 1) newEnemy.GetComponent<enemyScript>().direction_ = "clockwise";
                else if (newDirection == 2) newEnemy.GetComponent<enemyScript>().direction_ = "counterclockwise";
            }
        }
    }
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else if (enemyCount < 5)
        {
            timer = 0;
            enemyCount++;
            GameObject newEnemy = Instantiate(enemy, new Vector3 (Random.Range(-6, 7), Random.Range(-4, 5), 0), Quaternion.identity);
            newEnemy.SetActive(true);
            int enemyType = Random.Range(1, 4);
            if (enemyType == 1 || enemyType == 2) 
            {
                newEnemy.GetComponent<enemyScript>().movement = 1;
                int newDirection = Random.Range(1, 5);
                if (newDirection == 1) newEnemy.GetComponent<enemyScript>().direction_ = "up";
                else if (newDirection == 2) newEnemy.GetComponent<enemyScript>().direction_ = "down";
                else if (newDirection == 3) newEnemy.GetComponent<enemyScript>().direction_ = "left";
                else if (newDirection == 4) newEnemy.GetComponent<enemyScript>().direction_ = "right";
            }
            else
            {
                newEnemy.GetComponent<enemyScript>().movement = 2;
                int newDirection = Random.Range(1, 5);
                if (newDirection == 1) newEnemy.GetComponent<enemyScript>().rotatePoint = new Vector3(2, 0, 0);
                else if (newDirection == 2) newEnemy.GetComponent<enemyScript>().rotatePoint = new Vector3(-2, 0, 0);
                else if (newDirection == 3) newEnemy.GetComponent<enemyScript>().rotatePoint = new Vector3(0, 2, 0);
                else if (newDirection == 4) newEnemy.GetComponent<enemyScript>().rotatePoint = new Vector3(0, -2, 0);
                newDirection = Random.Range(1, 3);
                if (newDirection == 1) newEnemy.GetComponent<enemyScript>().direction_ = "clockwise";
                else if (newDirection == 2) newEnemy.GetComponent<enemyScript>().direction_ = "counterclockwise";
            }
        }
    }
}
