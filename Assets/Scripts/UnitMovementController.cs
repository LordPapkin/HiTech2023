using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitMovementController : MonoBehaviour
{
    public float velocity = 1f;
    public float rotationSpeed = 1f;
    private Vector3 target;
    private Quaternion toRotation;
    public Rigidbody unitRb;
    private MovementWaypointsManager movementWaypointsManager;

    // Start is called before the first frame update
    void Start()
    {
        movementWaypointsManager = MovementWaypointsManager.Instance;
        target = movementWaypointsManager.GetNextWP().position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!movementWaypointsManager.DestinationReached)
        {
            Movement();
        }
    }

    private bool OnTargetCheck()
    {
        if (target == unitRb.position)
            return true;
        return false;
    }

    private void Movement()
    {
        if (Vector3.Distance(target,unitRb.position)>0.1f)
        {
            unitRb.MovePosition(Vector3.MoveTowards(this.transform.position, target, Time.deltaTime * velocity));
            transform.LookAt(target);
        }
        else
        {
            target = movementWaypointsManager.GetNextWP().position;
        }
    }
}
