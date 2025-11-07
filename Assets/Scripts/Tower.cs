using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform curentEnemy;
    [Header("Tower Setup")]
    [SerializeField] private Transform towerHead;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float attackRange;
    private void Update()
    {
        RotateTowardsEnemy();
    }
    private void FindRandomEnemyInRange()
    {

    }
    private void RotateTowardsEnemy()
    {
        Vector3 direction = curentEnemy.position - towerHead.position; // Huong tu tower den enemy
        Quaternion lookRotation = Quaternion.LookRotation(direction); // Xoay de huong ve enemy
        Vector3 rotation = Quaternion.Lerp(towerHead.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles; // Noi suy giua huong hien tai va huong can xoay
        towerHead.rotation = Quaternion.Euler(rotation);// Ap dung goc xoay moi cho tower head
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(towerHead.position, attackRange);
    }
}
