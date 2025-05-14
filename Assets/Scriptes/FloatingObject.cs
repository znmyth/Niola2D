using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FloatingObject : MonoBehaviour
{
    public float baseAmplitude = 0.5f; // مقدار نوسان پایه
    public float floatFrequency = 1f; // سرعت نوسان
    public float rotationSpeed = 15f; // سرعت چرخش
    public float pushForce = 5f; // نیروی اعمال‌شده توسط بازیکن
    private float currentAmplitude; // مقدار نوسان متغیر
    private Vector3 startPos;
    private Vector3 adjustedStartPos;
    private Rigidbody2D rb;
    private bool usePhysics = false;

    [SerializeField] private float maxDrop = 1f; // بیشترین افت مجاز

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.isKinematic = false;

        startPos = transform.position;
        adjustedStartPos = startPos;
        currentAmplitude = baseAmplitude;
    }

    void Update()
    {
        if (!usePhysics)
        {
            float yOffset = Mathf.Sin(Time.time * floatFrequency) * currentAmplitude;
            Vector3 targetPos = new Vector3(adjustedStartPos.x, adjustedStartPos.y + yOffset, adjustedStartPos.z);
            rb.MovePosition(targetPos);
            rb.MoveRotation(rb.rotation + rotationSpeed * Time.deltaTime);
        }
    }

    public void AdjustFloatingHeight(float gravityValue)
    {
        if (gravityValue >= 1f)
        {
            usePhysics = true;
            rb.gravityScale = 1f;
        }
        else
        {
            usePhysics = false;
            rb.gravityScale = 0f;
            currentAmplitude = baseAmplitude * (1f - gravityValue);
            float offset = -maxDrop * gravityValue;
            adjustedStartPos = startPos + new Vector3(0, offset, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 pushDirection = (transform.position - collision.transform.position).normalized;
            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse); // ضربه از طرف بازیکن
        }
    }
}
