using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    private Rigidbody rbPlate;
    private Vector3 movement;
    public float speed = 3f;
    //public ParticleSystem dirtParticle;

    void Start()
    {
        rbPlate = GetComponent<Rigidbody>();
        movement = new Vector3(3, 5, 10);
        rbPlate.AddForce(movement * speed, ForceMode.Impulse);

        Invoke("DestroyPlate", 5);
    }


    public void DestroyPlate()
    {
        GameManager.isTimeDestroy = true;
        GameManager.countDestroyPlate++;
        GameObject.Find("GameManager").GetComponent<GameManager>().pushFireBtn.SetActive(true);
        Destroy(gameObject);
    }


}
