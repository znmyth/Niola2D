using UnityEngine;

public class EnergyPickup : MonoBehaviour
{
    public float jumpBoost = 3f; // مقدار افزایش انرژی

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().IncreaseJump(jumpBoost);
            Destroy(gameObject); // حذف شی انرژی از صحنه
        }
    }
}
