using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    [SerializeField] private Transform[] waypoint;
    public Transform[] GetWaypoints()
    {
        return waypoint;
    }
}
