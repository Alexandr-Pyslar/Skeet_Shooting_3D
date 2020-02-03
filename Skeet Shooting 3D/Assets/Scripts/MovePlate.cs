using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    private Rigidbody rbPlate;
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        rbPlate = GetComponent<Rigidbody>();
        movement = new Vector3(3, 5, 10);
        rbPlate.AddForce(movement * 1, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
