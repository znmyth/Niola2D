using UnityEngine;

public class StickToCeiling : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isSticking = false;
    private float stickTimer = 0f;
    public float stickDuration = 5f; // مدت زمان چسبیدن

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isSticking)
        {
            stickTimer -= Time.deltaTime;
            if (stickTimer <= 0)
            {
                StopCeilingMode();
            }
        }
    }

    public void ActivateCeilingMode()
    {
        isSticking = true;
        stickTimer = stickDuration;
        rb.gravityScale = -1f; // جاذبه معکوس بشه تا بره بالا
        transform.localScale = new Vector3(1, -1, 1); // تغییر ظاهر بازیکن
    }

    private void StopCeilingMode()
    {
        isSticking = false;
        rb.gravityScale = 1f; // برگشت به حالت عادی
        transform.localScale = new Vector3(1, 1, 1); // تنظیم ظاهر نرمال
    }
}
