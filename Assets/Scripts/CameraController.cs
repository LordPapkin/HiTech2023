using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Vector3 minConstraints;
    public Vector3 maxConstraints;

    public float cameraVelocity;

    // Start is called before the first frame update
    void Start()
    {
        minConstraints = new Vector3(-15f, 5f, 0f);
        maxConstraints = new Vector3(15f, 18f, 100f);
    }

    public bool IsInBounds()
    {
        if (transform.position.x >= minConstraints.x && transform.position.x <= maxConstraints.x)
        {
            if (transform.position.y >= minConstraints.y && transform.position.y <= maxConstraints.y)
            {
                if (transform.position.z >= minConstraints.z && transform.position.z <= maxConstraints.z)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void Update()
    {
        Vector3 moveDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W)) moveDir.x = -1;
        if (Input.GetKey(KeyCode.S)) moveDir.x = 1;
        if (Input.GetKey(KeyCode.A)) moveDir.z = -1;
        if (Input.GetKey(KeyCode.D)) moveDir.z = 1;
        moveDir.y = Input.mouseScrollDelta.y * 7f;

        transform.position += moveDir * cameraVelocity * Time.deltaTime;

    }
}
