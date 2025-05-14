using UnityEngine;

public class FloatingPlatform2D : MonoBehaviour
{
    public float moveSpeed = 2f; // سرعت حرکت آرام
    public float moveDistance = 3f; // فاصله حرکت به چپ و راست
    private Vector2 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float movement = movingRight ? moveSpeed * Time.deltaTime : -moveSpeed * Time.deltaTime;
        transform.position += new Vector3(movement, 0f, 0f);

        // تغییر جهت حرکت پس از رسیدن به حداکثر فاصله
        if (Vector2.Distance(startPos, transform.position) >= moveDistance)
        {
            movingRight = !movingRight;
        }
    }
}
