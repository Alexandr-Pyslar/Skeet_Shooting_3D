using UnityEngine;

public class MovePlate : MonoBehaviour
{
    private Rigidbody rbPlate;
    private Vector3 movement;
    private float speed = 0.05f;
    private float tempLevelMultiply;
    private int randomRange;
    public GameObject targetPoint;


    void Start()
    {
        rbPlate = GetComponent<Rigidbody>();

        GetRandomPositionTarget();

        if (PlayerPrefs.GetInt("currenteLevel") == 0)
        {
            tempLevelMultiply = PlayerPrefs.GetInt("currenteLevel") + 1;
        }
        else
        {
            tempLevelMultiply = PlayerPrefs.GetInt("currenteLevel");
        }
        rbPlate.AddForce(movement * (speed + (tempLevelMultiply / 20)), ForceMode.Impulse);
        Invoke("DestroyPlate", 8);

    }

    public void DestroyPlate()
    {
        GameManager.isTimeDestroy = true;
        GameManager.countDestroyPlate++;
        GameObject.Find("GameManager").GetComponent<GameManager>().pushFireBtn.SetActive(true);
        Destroy(gameObject);
    }

    public void GetRandomPositionTarget()
    {
        randomRange = Random.Range(-2, 3);
        Vector3 tarPointPos = targetPoint.transform.position;
        movement = new Vector3(tarPointPos.x + randomRange, tarPointPos.y + randomRange, tarPointPos.z + randomRange);
    }

}
