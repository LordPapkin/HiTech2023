using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitMovementController : MonoBehaviour
{
    private bool OnTarget=false;
    public float velocity = 1f;
    private Vector3 target;
    public Rigidbody unitRb;
    public MovementWaypointsManager MovementWaypointsManager;
    
    // Start is called before the first frame update
    void Start()
    {
        target = MovementWaypointsManager.currentWaypoint.position;
        OnTarget = OnTargetCheck();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!OnTargetCheck())
        {
            unitRb.MovePosition(transform.position + target * (Time.deltaTime * velocity));
        }
    }

    private bool OnTargetCheck()
    {
        if (target == unitRb.position)
            return true;
        return false;
    }
}
