using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MovementWaypointsManager : MonoBehaviour
{
    public Transform currentWaypoint;
    public Queue<Transform> Waypoints;
    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = Waypoints.Dequeue();
    }

    public Transform GetNextWP()
    {
        currentWaypoint = Waypoints.Dequeue();
        return currentWaypoint;
    }
}
