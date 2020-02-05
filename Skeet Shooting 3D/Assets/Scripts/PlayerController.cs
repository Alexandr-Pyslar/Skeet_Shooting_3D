using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 lastPosition;
    public float speed = 5f;
    private float limitX = 50f;
    private float limitY = 50f;

    private Quaternion originQuaternion;
    float dirX;
    float dirY;
   // public float sense = 0.5f;

    void Start()
    {
        originQuaternion = transform.rotation;
    }

    
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //RotateCam1();
        RotateCam2();
    }

    private void RotateCam1 ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            float dirX = Input.mousePosition.x - lastPosition.x;
            float dirY = Input.mousePosition.y - lastPosition.y;

            dirX = Mathf.Clamp(dirX, -limitX, limitX);
            dirY = Mathf.Clamp(dirY, -limitY, limitY);

            Quaternion rotationY = Quaternion.AngleAxis(dirX, Vector3.up);
            Quaternion rotationX = Quaternion.AngleAxis(-dirY, Vector3.right);
            transform.rotation = originQuaternion * rotationY * rotationX;
        }
    }

    private void RotateCam2()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Если точка клика равна начальной позиции камеры, то ничего не делать. Иначе

        }

        if (Input.GetMouseButton(0))
        {
            dirX += Input.GetAxis("Mouse X") * speed;
            dirY += Input.GetAxis("Mouse Y") * speed;


            dirY = Mathf.Clamp(dirY, -limitY, limitY);

            Quaternion rotationY = Quaternion.AngleAxis(dirX, Vector3.up);
            Quaternion rotationX = Quaternion.AngleAxis(-dirY, Vector3.right);
            transform.rotation = originQuaternion * rotationY * rotationX;
        }
    }

}
