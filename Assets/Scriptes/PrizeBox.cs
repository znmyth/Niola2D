using UnityEngine;

public class PrizeBox : MonoBehaviour
{
    public float timeToStick = 10f; // مدت زمان تأثیر جاذبه معکوس

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GravityController gravity = collision.gameObject.GetComponent<GravityController>();
            if (gravity != null)
            {
                gravity.InvertGravity(timeToStick);
            }

            // حذف جایزه پس از برخورد
            Destroy(gameObject);
        }
    }
}
