using UnityEngine;

public class EnemyCollision2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PLAYER"))
        {
            PlayerController2D player = other.GetComponent<PlayerController2D>();
            if (player != null)
            {
                player.frictionEnergy -= 0.1f;
                player.frictionEnergy = Mathf.Clamp(player.frictionEnergy, 0.1f, 1f);
                player.CheckExitGate();

                // پیدا کردن EnergySliderManager و به‌روزرسانی مقدار اسلایدر
                EnergySliderManager sliderManager = FindObjectOfType<EnergySliderManager>();
                if (sliderManager != null)
                {
                    sliderManager.UpdateEnergyBar(player.frictionEnergy);
                }
                else
                {
                    Debug.LogError("EnergySliderManager یافت نشد! مطمئن شوید که این اسکریپت در صحنه قرار دارد.");
                }

                Destroy(gameObject);
            }
        }
    }
}
