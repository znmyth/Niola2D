using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider energyBar; // نوار انرژی

    void Start()
    {
        if (energyBar != null)
        {
            energyBar.minValue = 0.1f;
            energyBar.maxValue = 1f;
            energyBar.value = 0.1f; // مقدار اولیه تنظیم شود
        }
        else
        {
            Debug.LogError("🚨 Slider مقداردهی نشده است!");
        }
    }

    public void UpdateEnergyBar(float newValue)
    {
        if (energyBar != null)
        {
            Debug.Log($"🔄 مقدار جدید نوار انرژی: {newValue}"); // بررسی مقدار جدید
            energyBar.value = newValue; // تنظیم مقدار اسلایدر
        }
        else
        {
            Debug.LogError("🚨 نوار انرژی یافت نشد! بررسی کنید که در Inspector مقداردهی شده باشد.");
        }
    }
}
