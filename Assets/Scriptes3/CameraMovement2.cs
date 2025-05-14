using UnityEngine;

public class CameraMovement2 : MonoBehaviour
{
    public GameObject target; // هدف (بازیکن)
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    [Header("Camera Limits")]
    public float minY = -5f;  // حداقل مقدار Y برای حرکت دوربین
    public float maxY = 50f;  // حداکثر مقدار Y برای حرکت دوربین

    void Update()
    {
        float targetY = Mathf.Clamp(target.transform.position.y + offset.y, minY, maxY);
        Vector3 desiredPosition = new Vector3(transform.position.x, targetY, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
