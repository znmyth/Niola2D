using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target; // هدف (بازیکن)
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    [Header("Camera Limits")]
    public float minX = -50f;
    public float maxX = 50f;

    void Update()
    {
        float targetX = Mathf.Clamp(target.transform.position.x + offset.x, minX, maxX);
        Vector3 desiredPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
