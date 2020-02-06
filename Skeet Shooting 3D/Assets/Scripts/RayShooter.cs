using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera cam;
    public static bool inAim = false;
    public GameObject platePrefab;
    public ParticleSystem dirtParticle;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        inAim = false;
        Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
        Ray ray = cam.ScreenPointToRay(point);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Target") 
        {

            inAim = true;
            if (ProgressBar.readyToShot)
            {
                //Debug.Log(hit.distance);

                GameObject.Find("GameManager").GetComponent<GameManager>().pushFireBtn.SetActive(true);
                Destroy(hit.transform.gameObject);
                GameManager.score++;
                GameManager.countDestroyPlate++;
                Instantiate(dirtParticle, hit.point, Quaternion.identity);
                dirtParticle.Play();
            }                 
        }
        else
        {
            ProgressBar.currentAmount = 0;
        }
    }

    //Задержка удаления после выстрела пока долетит снаряд


    public void WaitSec()
    {
        Debug.Log("wait");
    }
    
}
