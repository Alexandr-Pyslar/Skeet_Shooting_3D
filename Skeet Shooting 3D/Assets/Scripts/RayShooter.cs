using UnityEngine;
using UnityEngine.UI;


public class RayShooter : MonoBehaviour
{
    private Camera cam;
    public static bool inAim = false;
    public static bool isDestroy= false;

    public GameObject platePrefab;
    public ParticleSystem dirtParticle;
    public Text textDistance;

    void Start()
    {
        cam = Camera.main;     
    }

    void Update()
    {
        inAim = false;
        Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
        Ray ray = cam.ScreenPointToRay(point);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Target") 
        {

            inAim = true;
            if (ProgressBar.readyToShot && Guns.hitDistance >= hit.distance)
            {

                GameObject.Find("GameManager").GetComponent<GameManager>().pushFireBtn.SetActive(true);
                Destroy(hit.transform.gameObject);
                GameManager.playShoot = true;
                isDestroy = true;
                GameManager.score++;
                GameManager.countDestroyPlate++;
                Instantiate(dirtParticle, hit.point, Quaternion.identity);
                dirtParticle.Play();
                
            } else if (ProgressBar.currentAmount > 0 && Guns.hitDistance < hit.distance )
            {
                textDistance.gameObject.SetActive(true);
                Debug.Log(hit.distance + " Guns.hitDistance: " + Guns.hitDistance);
            }

        }
        else
        {
            ProgressBar.currentAmount = 0;
            textDistance.gameObject.SetActive(false);
        }
    }



    
}
