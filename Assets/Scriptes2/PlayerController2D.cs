using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float speed = 10f;
    public float frictionEnergy = 0.1f;
    public float jumpForce = 3f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private EnergySliderManager energySliderManager;
    private ExitGateManager exitGateManager;
    public AudioSource audioSource;
    public AudioClip energySound;
    public AudioClip hitSound;
    public AudioClip ExitSound;

    public GameObject exitGate;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        energySliderManager = FindObjectOfType<EnergySliderManager>();

        if (energySliderManager != null)
        {
            energySliderManager.UpdateEnergyBar(frictionEnergy); // مقدار اولیه نوار انرژی را تنظیم کن
        }
        else
        {
            Debug.LogError("EnergySliderManager یافت نشد! مطمئن شوید که این اسکریپت در صحنه قرار دارد.");
        }

        exitGateManager = FindObjectOfType<ExitGateManager>();

        if (exitGateManager == null)
        {
            Debug.LogError("ExitGateManager یافت نشد! مطمئن شوید که این اسکریپت در صحنه قرار دارد.");
        }

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        speed = Mathf.Lerp(1f, 10f, (1f - frictionEnergy));

        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = null; // وقتی از پلتفرم جدا شد، بازیکن مستقل شود
        }
    }

    private void LoadNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
    }

    public void CheckExitGate()
    {
        if (frictionEnergy >= 1f)
        {
            float exitOffset = 2f; // فاصله دروازه خروج از بازیکن
            exitGate.transform.position = new Vector2(transform.position.x + exitOffset, transform.position.y);

            exitGate.SetActive(true); // نمایش دروازه خروج
        }
        else
        {
            exitGate.SetActive(false); // مخفی کردن دروازه خروج
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Energy")) // جمع‌آوری انرژی
        {
            frictionEnergy += 0.1f;
            frictionEnergy = Mathf.Clamp(frictionEnergy, 0.1f, 1f);

            energySliderManager.UpdateEnergyBar(frictionEnergy); // تنظیم مقدار نوار انرژی

            if (exitGateManager != null)
            {
                exitGateManager.CheckExitGate(frictionEnergy); // بررسی نمایش دروازه خروج
            }

            Destroy(other.gameObject);
        }

        if (other.CompareTag("ExitGate") && frictionEnergy >= 1f) // بررسی تگ درست دروازه خروج
        {
            LoadNextLevel();
        }

        if (other.CompareTag("Energy"))
        {
            audioSource.PlayOneShot(energySound); // پخش صدای جمع‌آوری انرژی
            Destroy(other.gameObject);
        }

        if (other.CompareTag("enemy"))
        {
            audioSource.PlayOneShot(hitSound); // پخش صدای برخورد با دشمن
            Destroy(other.gameObject);
        }


        if (other.CompareTag("ExitGate")) // پخش صدای جایزه 🎯
        {
            audioSource.PlayOneShot(ExitSound); // پخش صدای دریافت جایزه
            Destroy(other.gameObject);
        }



    }
}
