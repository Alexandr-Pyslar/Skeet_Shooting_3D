    using UnityEngine;
    using UnityEngine.UI;

public class RayShooter : MonoBehaviour
{
    private Camera cam;
    public static bool inAim = false;
    public static bool isDestroy= false;

    public GameObject platePrefab;
    public GameObject canvasProgressbar;
    public ParticleSystem dirtParticle;
    public Text textDistance;

    public static float randomRot = 20f;
    private RaycastHit hit2;
    public Transform firePoint;
    private Transform firePointStartTr;



    void Start()
    {
        cam = Camera.main;
        firePointStartTr = firePoint;
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
            if (ProgressBar.readyToShot)
            {
                if(Guns.hitDistance >= hit.distance)
                {
                    Shoot(hit);
                }

                if (Guns.hitDistance < hit.distance)
                {
                    ShootAfterFarDistance();
                    
                }
                
            } else if (ProgressBar.currentAmount > 0 && Guns.hitDistance < hit.distance )
            {
                textDistance.gameObject.SetActive(true);
            }

        }
        else
        {
            ProgressBar.currentAmount = 0;
            textDistance.gameObject.SetActive(false);
        }
    }   

    public void Shoot(RaycastHit hit)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().pushFireBtn.SetActive(true);
        Destroy(hit.transform.gameObject);
        GameManager.playShoot = true;
        isDestroy = true;
        GameManager.score++;
        GameManager.countDestroyPlate++;
        Instantiate(dirtParticle, hit.point, Quaternion.identity);
        dirtParticle.Play();
    }

    public void ShootAfterFarDistance()
    {
            firePoint.localRotation = Quaternion.identity;
            firePoint.localRotation = Quaternion.Euler(
                firePointStartTr.localRotation.x + Random.Range(-randomRot / 10f, randomRot / 10f), 
                firePointStartTr.localRotation.y + Random.Range(-randomRot / 10f, randomRot / 10f),
                firePointStartTr.localRotation.z + Random.Range(-randomRot / 10f, randomRot / 10f));
            Vector3 fwd = firePoint.TransformDirection(Vector3.forward);

        GameManager.playShoot = true;
        if (Physics.Raycast(firePoint.position, fwd, out hit2) && hit2.transform.gameObject.tag == "Target")
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().pushFireBtn.SetActive(true);
                Destroy(hit2.transform.gameObject);
                isDestroy = true;
                GameManager.score++;
                GameManager.countDestroyPlate++;
                Instantiate(dirtParticle, hit2.point, Quaternion.identity);
                dirtParticle.Play();
            } else 
            {
                ProgressBar.currentAmount = 0;
            }
    }


}
