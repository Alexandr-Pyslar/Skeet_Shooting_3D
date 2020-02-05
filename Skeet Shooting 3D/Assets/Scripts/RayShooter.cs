using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera cam;
    public static bool inAim = false;
    
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
                GameManager.score++;
                Destroy(hit.transform.gameObject);
            }                 
        }
        else
        {
            ProgressBar.currentAmount = 0;
        }
    }


}
