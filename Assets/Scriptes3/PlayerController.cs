using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 3f;
    private Rigidbody2D rb;
    private float moveInput;
    public AudioSource audioSource;
    public AudioClip energySound;
    public AudioClip hitSound;
    public AudioClip ExitSound;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // حرکت چپ و راست
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // پرش با Space
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public void IncreaseJump(float amount)
    {
        jumpForce += amount;

        // وقتی مقدار پرش به ۱۲ رسید، چرخش اشیا فعال شود
        if (jumpForce >= 12f)
        {
            StartRotatingObjects();
        }
    }

    private void StartRotatingObjects()
    {
        GameObject[] rotatingObjects = GameObject.FindGameObjectsWithTag("Rotating"); // پیدا کردن اشیا با تگ "Rotating"
        foreach (GameObject obj in rotatingObjects)
        {
            obj.GetComponent<RotateObject>().StartRotation(); // فعال‌سازی چرخش
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("بازیکن وارد محدوده انرژی شد!"); // بررسی برخورد
        if (other.CompareTag("Energy"))
        {
            IncreaseJump(3f);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Energy"))
        {
            audioSource.PlayOneShot(energySound); // پخش صدای جمع‌آوری انرژی
            Destroy(other.gameObject);
        }

        if (other.CompareTag("ENEMY"))
        {
            audioSource.PlayOneShot(hitSound); // پخش صدای برخورد با دشمن
            Destroy(other.gameObject);
        }


        if (other.CompareTag("by")) // پخش صدای جایزه 🎯
        {
            audioSource.PlayOneShot(ExitSound); // پخش صدای دریافت جایزه
            Destroy(other.gameObject);
        }
    }

}
