using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject platePrefab;

 
    // Start is called before the first frame update
    void Start()
    {     
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlate()
    {
        Instantiate(platePrefab, new Vector3(-3f, .5f, 0), Quaternion.identity);
    }
}
