using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    private Rigidbody rbPlate;
    private Vector3 movement;
    private float speed = 0.05f;
    private float tempLevelMultiply;
    private float randomRange;

    void Start()
    {
        randomRange = Random.Range(3f, 6f);
        rbPlate = GetComponent<Rigidbody>();
        movement = new Vector3(randomRange, randomRange, 10);
        if (PlayerPrefs.GetInt("currenteLevel") == 0)
        {
            tempLevelMultiply = PlayerPrefs.GetInt("currenteLevel") + 1;
        }
        else
        {
            tempLevelMultiply = PlayerPrefs.GetInt("currenteLevel");
        }
        rbPlate.AddForce(movement * (speed + (tempLevelMultiply / 20)), ForceMode.Impulse);
        Debug.Log(speed + (tempLevelMultiply / 20));
        Invoke("DestroyPlate", 8);

    }

    private void Update()
    {
        
    }


    public void DestroyPlate()
    {
        GameManager.isTimeDestroy = true;
        GameManager.countDestroyPlate++;
        GameObject.Find("GameManager").GetComponent<GameManager>().pushFireBtn.SetActive(true);
        Destroy(gameObject);
    }


}
