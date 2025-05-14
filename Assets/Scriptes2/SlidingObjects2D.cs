using UnityEngine;

public class SlidingObjects2D : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerController2D player;
    public float moveSpeed = 5f; // سرعت اولیه حرکت به چپ و راست
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController2D>();

        // اعمال نیروی اولیه برای حرکت خودکار
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    void Update()
    {
        if (player.frictionEnergy >= 1f)
        {
            rb.velocity = Vector2.zero; // توقف کامل جسم
        }
        else
        {
            // حرکت جسم به سمت چپ و راست
            if (movingRight)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // وقتی جسم به دیواره برخورد کند، جهت حرکت تغییر کند
        if (collision.gameObject.CompareTag("Wall"))
        {
            movingRight = !movingRight;
        }
    }
}
