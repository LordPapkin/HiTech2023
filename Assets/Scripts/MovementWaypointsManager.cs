using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MovementWaypointsManager : MonoBehaviour
{
    public Queue<Transform> WaypointsQueue;

    public List<Transform> Waypoints;

    public static MovementWaypointsManager Instance => instance;

    private static MovementWaypointsManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        WaypointsQueue = new Queue<Transform>();
        foreach (Transform WP in Waypoints)
        {
            WaypointsQueue.Enqueue(WP);
        }
    }

    public Queue<Transform> GetWaypointsQueue()
    {
        Queue<Transform> waypointsQueue = new Queue<Transform>();
        foreach (Transform WP in Waypoints)
        {
            waypointsQueue.Enqueue(WP);
        }
        return waypointsQueue;
    }
}
