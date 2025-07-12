using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class MatchUp : MonoBehaviour
{
    public List<float> wires = new List<float>();
    [SerializeField] public List<GameObject> mission = new List<GameObject>();
    GameObject rand;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wires.Add(-9f);
        wires.Add(-6f);
        wires.Add(-3f);
        wires.Add(0f);
        wires.Add(3f);
        wires.Add(6f);
        wires.Add(9f);
        foreach (float i in wires)
        {
            Debug.Log(i);
        }
        foreach (GameObject i in mission)
        {
            rand = mission[Random.Range(0, mission.Count)];
            rand.transform.position = new Vector3(wires[Random.Range(0, wires.Count)], -3, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    

}
