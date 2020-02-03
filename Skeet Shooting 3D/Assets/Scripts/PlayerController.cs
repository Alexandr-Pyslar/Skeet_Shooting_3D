using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 lastPosition;
    public float speed = 2f;
    private float limitX = 15f;
    private float limitY = 8.8f;

    Quaternion originQuaternion;
    float angleHorizontal;
    float angleVertical;
    float mouseX;
    float mouseSense = 5;
    // Start is called before the first frame update
    void Start()
    {
        originQuaternion = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(moveX, 0, moveZ) * 5 * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            angleHorizontal += Input.GetAxis("Mouse X") * mouseSense;
            angleVertical += Input.GetAxis("Mouse Y") * mouseSense;

            angleVertical = Mathf.Clamp(angleVertical, -50, 50);
            Quaternion rotationY = Quaternion.AngleAxis(angleHorizontal, Vector3.up);
            Quaternion rotationX = Quaternion.AngleAxis(-angleVertical, Vector3.right);
            transform.rotation = originQuaternion * rotationY * rotationX;
        }

    }
}
