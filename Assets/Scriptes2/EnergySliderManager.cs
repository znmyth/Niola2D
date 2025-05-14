using UnityEngine;
using UnityEngine.UI;

public class EnergySliderManager : MonoBehaviour
{
    public Slider slider2; // اسلایدر برای نمایش انرژی بازیکن

    void Start()
    {
        slider2.minValue = 0.1f;
        slider2.maxValue = 1f;
        slider2.value = 0.1f; // مقدار اولیه اسلایدر
    }

    public void UpdateEnergyBar(float energy)
    {
        slider2.value = energy; // تنظیم مقدار اسلایدر بر اساس مقدار انرژی
    }
}
