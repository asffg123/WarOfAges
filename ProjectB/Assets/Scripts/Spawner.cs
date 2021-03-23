using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Reference to game object
    public GameObject Unit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to spawn unit
    public void SpawnUnit()
    {
        GameObject TestUnit = GameObject.Instantiate(Unit);
        TestUnit.transform.position = this.transform.position;
    }
}
