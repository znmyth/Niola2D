using UnityEngine;

public class EnergyCollectible : MonoBehaviour
{
    public float gravityAmount = 0.1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // افزایش گرانش نیولا
            GravityController gravity = other.GetComponent<GravityController>();
            if (gravity != null)
            {
                gravity.AddGravity(gravityAmount);
            }

            // اطلاع به GravityManager
            GravityManager gm = FindObjectOfType<GravityManager>();
            if (gm != null)
            {
                gm.OnEnergyCollected();
            }

            // حذف ذره پس از جمع‌آوری
            Destroy(gameObject);
        }
    }
}
