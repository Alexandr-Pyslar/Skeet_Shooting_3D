using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Guns : MonoBehaviour
{
    public GameObject gun0;
    public GameObject gun1;
    public GameObject gun2;

    public Button btn0;
    public Button btn1;
    public Button btn2;

    public static int hitDistance = 20;
    public static Vector3 sizeColliderPlate;



    void Start()
    {
       sizeColliderPlate = new Vector3(1, 2 ,1);
}


    void Update()
    {
        if (PlayerPrefs.GetInt("isGun1Purchased") != 1)
        {
            btn1.interactable = false;
        } else
        {
            btn1.interactable = true;
        }
        if (PlayerPrefs.GetInt("isGun2Purchased") != 1)
        {
            btn2.interactable = false;
        }
        else
        {
            btn2.interactable = true;
        }
    }

    public void ShowGun0()
    {
        gun0.SetActive(true);
        gun1.SetActive(false);
        gun2.SetActive(false);

        //weapon characteristics
        hitDistance = 20;
        sizeColliderPlate = new Vector3(1.2f, 6, 1.2f);
    }

    public void ShowGun1()
    {
        gun0.SetActive(false);
        gun1.SetActive(true);
        gun2.SetActive(false);

        //weapon characteristics
        hitDistance = 40;
        sizeColliderPlate = new Vector3(2.5f, 8f, 2.5f);
    }

    public void ShowGun2()
    {
        gun0.SetActive(false);
        gun1.SetActive(false);
        gun2.SetActive(true);

        //weapon characteristics
        hitDistance = 100;
        sizeColliderPlate = new Vector3(1.2f, 6, 1.2f);
    }

}
