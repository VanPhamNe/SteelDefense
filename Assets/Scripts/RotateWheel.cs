using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    [SerializeField] private Vector3 rotationVector;
    [SerializeField] private float rotationSpeed;
    private void Update()
    {
        float newRotationSpeed = rotationSpeed * 100;
        transform.Rotate(rotationVector * newRotationSpeed * Time.deltaTime);
    }
}
