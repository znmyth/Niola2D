using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject player;
    public Transform startPoint; // نقطه شروع بازیکن

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = startPoint.position; // بازگشت به نقطه شروع
        }
    }
}
