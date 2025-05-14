using UnityEngine;
using System.Collections;

public class GravityController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float originalGravity = 1f;
    private UIManager uiManager; // مدیریت UI برای نمایش نوار انرژی
    public AudioSource audioSource;
    public AudioClip energySound;
    public AudioClip hitSound;
    public AudioClip prizeSound;
    public AudioClip ExitSound;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("🚨 Rigidbody2D یافت نشد!");
            return;
        }

        rb.gravityScale = 0.1f; // مقدار اولیه جاذبه بازیکن (رفع مشکل مقداردهی اولیه)
        uiManager = FindObjectOfType<UIManager>();

        if (uiManager != null)
        {
            uiManager.UpdateEnergyBar(rb.gravityScale);
        }
        else
        {
            Debug.LogError("🚨 UIManager یافت نشد!");
        }


        audioSource = GetComponent<AudioSource>();
    }


    public void InvertGravity(float duration)
    {
        if (rb == null) return;

        StopAllCoroutines();
        StartCoroutine(GravityEffect(duration));
    }

    private IEnumerator GravityEffect(float time)
    {
        float original = rb.gravityScale;
        rb.gravityScale = -original;
        yield return new WaitForSeconds(time);
        rb.gravityScale = original;
    }

    public void AddGravity(float amount)
    {
        if (rb == null) return;

        rb.gravityScale = Mathf.Clamp(rb.gravityScale + amount, 0f, 1f);
        Debug.Log($"✅ جاذبه بازیکن افزایش یافت! مقدار جدید: {rb.gravityScale}");

        if (uiManager != null)
        {
            uiManager.UpdateEnergyBar(rb.gravityScale); // بروزرسانی نوار انرژی
        }
    }

    public void DecreaseGravity(float amount)
    {
        if (rb == null) return;

        rb.gravityScale = Mathf.Clamp(rb.gravityScale - amount, 0f, 1f);
        Debug.Log($"⚡ برخورد با دشمن! مقدار جاذبه جدید: {rb.gravityScale}");

        if (uiManager != null)
        {
            uiManager.UpdateEnergyBar(rb.gravityScale); // بروزرسانی نوار انرژی
        }
    }

    public float GetGravityScale()
    {
        return rb != null ? rb.gravityScale : 0f;
    }


    private void LoadNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Exit") && rb.gravityScale >= 1f) // بررسی تگ درست دروازه خروج
        {
            LoadNextLevel();
        }

        if (other.CompareTag("Energy"))
        {
            audioSource.PlayOneShot(energySound); // پخش صدای جمع‌آوری انرژی
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(hitSound); // پخش صدای برخورد با دشمن
            Destroy(other.gameObject);
        }

        if (other.CompareTag("prize")) // پخش صدای جایزه 🎯
        {
            audioSource.PlayOneShot(prizeSound); // پخش صدای دریافت جایزه
            Destroy(other.gameObject);
        }

                if (other.CompareTag("Exit")) // پخش صدای جایزه 🎯
        {
            audioSource.PlayOneShot(ExitSound); // پخش صدای دریافت جایزه
            Destroy(other.gameObject);
        }

    }


}
