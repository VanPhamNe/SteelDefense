using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] waypoint;
    [SerializeField] private float turnSpeed = 10;
    public int waypointIndex;
    private NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; // Khong tu dong quay theo huong di chuyen
        agent.avoidancePriority = Mathf.RoundToInt(agent.speed * 10); // Thiet lap uu tien tranh va cham
    }
    private void Update()
    {
        FaceTarget(agent.steeringTarget);
        //Check xem agent co gan voi target point hien tai 
        if(agent.remainingDistance < .5f)
        {
            //Di chuyen den diem tiep theo
            agent.SetDestination(GetNextWayPoint());
        }
    }
    private Vector3 GetNextWayPoint()
    {
        if (waypointIndex >= waypoint.Length) {
            waypointIndex = 0;
            //return transform.position;
        }
        Vector3 targetPoint = waypoint[waypointIndex].position;
        waypointIndex++;
        return targetPoint;
    }
    private void FaceTarget(Vector3 newTarget)
    {
        Vector3 directionToTarget = newTarget-transform.position;
        directionToTarget.y = 0; // Khong quay len xuong
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

    }
}
