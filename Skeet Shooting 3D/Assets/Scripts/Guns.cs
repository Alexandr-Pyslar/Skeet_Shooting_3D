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

    public static int hitDistance = 22;
    public static Vector3 sizeColliderPlate;

    public AudioSource audioPlayer;
    public AudioClip[] audoiShoot;

    private int gunSelect = 0;



    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        sizeColliderPlate = new Vector3(1.2f, 7, 1.2f);
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

         if (ProgressBar.readyToShot && GameManager.playShoot)
        {
            switch(gunSelect)
            {
                case 0:
                    audioPlayer.PlayOneShot(audoiShoot[0], 1f);
                    GameManager.playShoot = false;
                    break;
                case 1:
                    audioPlayer.PlayOneShot(audoiShoot[1], 1f);
                    GameManager.playShoot = false;
                    break;
                case 2:
                    audioPlayer.PlayOneShot(audoiShoot[2], 1f);
                    GameManager.playShoot = false;
                    break;
            }
        }
    }

    public void ShowGun0()
    {
        gun0.SetActive(true);
        gun1.SetActive(false);
        gun2.SetActive(false);

        //weapon characteristics
        hitDistance = 22;
        sizeColliderPlate = new Vector3(1.2f, 7, 1.2f);
        gunSelect = 0;
    }

    public void ShowGun1()
    {
        gun0.SetActive(false);
        gun1.SetActive(true);
        gun2.SetActive(false);

        //weapon characteristics
        hitDistance = 40;
        sizeColliderPlate = new Vector3(2.5f, 10f, 2.5f);
        gunSelect = 1;
    }

    public void ShowGun2()
    {
        gun0.SetActive(false);
        gun1.SetActive(false);
        gun2.SetActive(true);

        //weapon characteristics
        hitDistance = 100;
        sizeColliderPlate = new Vector3(1.5f, 8, 1.5f);
        gunSelect = 2;
    }

}
