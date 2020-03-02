using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float limitX = 70f;
    private float limitY = 50f;

    private Quaternion originQuaternion;
    float dirX;
    float dirY;

    public Transform player;
    public float speed = 2f;

    void Start()
    {
        originQuaternion = transform.rotation;
    }


    private void FixedUpdate()
    {
        //RotateCamPC();
        RotateCamAndroid();
    }

    private void RotateCamPC()
    {
        if (Input.GetMouseButton(0))
        {

            dirX += Input.GetAxis("Mouse X");
            dirY += Input.GetAxis("Mouse Y");

            dirY = Mathf.Clamp(dirY, -limitY, limitY);
            dirX = Mathf.Clamp(dirX, -limitX, limitX);

            Quaternion rotationY = Quaternion.AngleAxis(dirX, Vector3.up);
            Quaternion rotationX = Quaternion.AngleAxis(-dirY, Vector3.right);
            transform.rotation = originQuaternion * rotationY * rotationX;
        }
    }

    private void RotateCamAndroid()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            dirX -= Input.GetTouch(0).deltaPosition.y * speed * Time.deltaTime;
            dirY += Input.GetTouch(0).deltaPosition.x * speed * Time.deltaTime;

            dirX = Mathf.Clamp(dirX, -limitY, limitY);
            dirY = Mathf.Clamp(dirY, -limitX, limitX);

            player.eulerAngles = new Vector3(dirX, dirY, 0.0f);
        }
    }
    }





