using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MatchUp : MonoBehaviour
{
    public List<float> wires = new List<float>();

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

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    

}
