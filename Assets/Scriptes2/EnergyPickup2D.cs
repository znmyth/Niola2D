using UnityEngine;

public class EnergyPickup2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController2D player = other.GetComponent<PlayerController2D>();
            if (player != null)
            {
                player.frictionEnergy += 0.1f;
                player.frictionEnergy = Mathf.Clamp(player.frictionEnergy, 0.1f, 1f);
                player.CheckExitGate();
                Destroy(gameObject); // حذف ذره انرژی پس از برخورد
            }
        }
    }

    
}
