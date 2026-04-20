using UnityEngine;

public class RotateHayBale : MonoBehaviour
{
    public Vector3 rotationSpeed;

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
