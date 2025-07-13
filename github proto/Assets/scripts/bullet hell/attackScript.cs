using UnityEngine;

public class attackScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.up * 5f * Time.deltaTime;
    }
}
