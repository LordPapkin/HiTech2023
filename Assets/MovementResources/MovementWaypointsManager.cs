using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MovementWaypointsManager : MonoBehaviour
{
    public bool DestinationReached { get; private set; } = false;
    public Transform currentWaypoint;
    public Queue<Transform> WaypointsQueue;

    public List<Transform> Waypoints;
    // Start is called before the first frame update
    void Start()
    {
        WaypointsQueue = new Queue<Transform>();
        foreach (Transform WP in Waypoints)
        {
            WaypointsQueue.Enqueue(WP);
        }
    }

    public Transform GetNextWP()
    {
        if (WaypointsQueue.Count==0)
        {
            Debug.Log("Journey finished");
            DestinationReached = true;
            return currentWaypoint;
        }
        Debug.Log("GetNext");
        currentWaypoint = WaypointsQueue.Dequeue();
        return currentWaypoint;
    }
}
