using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Vector3 minConstraints;
    public Vector3 maxConstraints;

    public float cameraVelocity;
    private float velocityNormal;
    private float velocityHaiai;

    // Start is called before the first frame update
    void Start()
    {
        minConstraints = new Vector3(-15f, 5f, 0f);
        maxConstraints = new Vector3(15f, 18f, 100f);
        velocityNormal = cameraVelocity;
        velocityHaiai = 2.5f * cameraVelocity;
    }

    private void Update()
    {
        Vector3 moveDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W)) moveDir.x = -1;
        if (Input.GetKey(KeyCode.S)) moveDir.x = 1;
        if (Input.GetKey(KeyCode.A)) moveDir.z = -1;
        if (Input.GetKey(KeyCode.D)) moveDir.z = 1;
        moveDir.y = (-1f)*Input.mouseScrollDelta.y * 7f;

        if (Input.GetKey(KeyCode.LeftShift))
            cameraVelocity = velocityHaiai;
        else
            cameraVelocity = velocityNormal;

        if (transform.position.x <= -15)
        {
            moveDir.x += 1.1f;
        }
        if (transform.position.x >= 15)
        {
            moveDir.x -= 1.1f;
        }
        if (transform.position.z <= 0)
        {
            moveDir.z += 1.1f;
        }
        if (transform.position.z >= 100)
        {
            moveDir.z -= 1.1f;
        }
        
        if (transform.position.y <= 5)
        {
            moveDir.y += 2.1f;
        }
        if (transform.position.y >= 18)
        {
            moveDir.y -= 2.1f;
        }
        
        transform.position += moveDir * cameraVelocity * Time.deltaTime;
        //minConstraints = new Vector3(-15f, 5f, 0f);
        //maxConstraints = new Vector3(15f, 18f, 100f);

    }
}
