using UnityEngine;

public class MovingBlock2 : MonoBehaviour
{
    public float speed = 3f; // سرعت حرکت
    public bool moveUp = true; // جهت حرکت (بالا یا پایین)
    private bool canMove = false; // حرکت در ابتدا غیرفعال است
    private float maxDistance = 5f; // مقدار حداکثر جابه‌جایی
    private Vector2 startPos; // موقعیت اولیه سکو

    void Start()
    {
        startPos = transform.position; // ذخیره موقعیت اولیه
    }

    void Update()
    {
        if (canMove)
        {
            float direction = moveUp ? 1f : -1f;
            transform.Translate(Vector2.up * direction * speed * Time.deltaTime);

            // بررسی محدوده حرکت برای جلوگیری از حرکت بی‌نهایت
            if (Mathf.Abs(transform.position.y - startPos.y) >= maxDistance)
            {
                moveUp = !moveUp; // تغییر جهت حرکت
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player")) // بررسی برخورد فیزیکی
        {
            Debug.Log("بازیکن به مربع برخورد کرد، حرکت آغاز می‌شود!");
            canMove = true; // فعال شدن حرکت
        }
    }
}
