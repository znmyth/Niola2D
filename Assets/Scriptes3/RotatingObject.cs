using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public bool rotateRight = true;
    private bool canRotate = false; // چرخش در ابتدا غیرفعال است

    void Update()
    {
        if (canRotate) // چرخش فقط زمانی فعال شود که مقدار انرژی پرتاب به 12 برسد
        {
            float direction = rotateRight ? 1f : -1f;
            transform.Rotate(0, 0, direction * rotationSpeed * Time.deltaTime);
        }
    }

    public void StartRotation() // متد فعال‌سازی چرخش
    {
        canRotate = true;
    }
}
