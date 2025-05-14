using UnityEngine;

public class PrizeBoxTrigger : MonoBehaviour
{
    public float invertedDuration = 10f; // مدت زمان معکوس شدن جاذبه

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GravityController gravity = other.gameObject.GetComponent<GravityController>();
            if (gravity != null)
            {
                gravity.InvertGravity(invertedDuration);
            }

            // حذف جایزه پس از برخورد
            Destroy(gameObject);
        }
    }
}
