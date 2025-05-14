using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;      
    public float jump;       
    private float Move;           
    private Rigidbody2D rb;       
    private bool isJumping;        

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
        Move = Input.GetAxis("Horizontal"); 

        rb.velocity = new Vector2(Move * speed, rb.velocity.y); 

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            float gravity = rb.gravityScale;

            if (gravity > 0)
            {
                rb.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse); // پرش به بالا
            }
            else
            {
                rb.AddForce(new Vector2(0f, -jump), ForceMode2D.Impulse); // پرش به پایین (در حالت سقف)
            }

            isJumping = true; // بعد از پرش، مقدار صحیح تنظیم شود
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Ceiling"))
        {
            Debug.Log("✅ بازیکن روی زمین یا سقف قرار گرفت!");
            isJumping = false;  
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Ceiling"))
        {
            Debug.Log("⚡ بازیکن از زمین یا سقف جدا شد!");
            isJumping = true;  
        }
    }
}
