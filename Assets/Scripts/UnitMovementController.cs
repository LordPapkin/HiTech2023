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
    private Queue<Transform> waypoints;
    private bool destinationReached = false;
    private int n = 0;
    private BasicUnit unit;

    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponent<BasicUnit>();
        movementWaypointsManager = MovementWaypointsManager.Instance;
        waypoints = movementWaypointsManager.GetWaypointsQueue();
        target = waypoints.Dequeue().position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!destinationReached || !IsOnTarget())
        {
            Movement();
        }
    }

    private bool IsOnTarget()
    {
        return (Vector3.Distance(target, unitRb.position) < 0.1f);
    }
    protected virtual void Movement()
    {
        if (Vector3.Distance(target,unitRb.position) > 0.2f)
        {
            unitRb.MovePosition(Vector3.MoveTowards(this.transform.position, target, Time.deltaTime * velocity));
            transform.LookAt(target);
        }
        else
        {
            if (!destinationReached)
            {
                target = waypoints.Dequeue().position;
                Debug.Log("WP reached" + n++);
            }

            destinationReached = (waypoints.Count == 0);
            if(destinationReached)
                unit.ArriveInBase();
        }
    }
}
