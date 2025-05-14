using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FloatingMovement : MonoBehaviour
{
    public float floatForce = 2f; // میزان نیروی شناور شدن
    public float floatFrequency = 1f; // سرعت نوسان
    public float rotationTorque = 0.5f; // میزان چرخش
    private Rigidbody2D rb;
    private bool isFloating = true;
    private float startTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time;
    }

    void FixedUpdate()
    {
        if (isFloating)
        {
            float floatOffset = Mathf.Sin((Time.time - startTime) * floatFrequency);
            Vector2 force = new Vector2(0f, floatOffset * floatForce);
            rb.AddForce(force, ForceMode2D.Force);
            rb.AddTorque(rotationTorque * Mathf.Sin(Time.time), ForceMode2D.Force);
        }
    }

    public void StopFloating()
    {
        isFloating = false;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
}
