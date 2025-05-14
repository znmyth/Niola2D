using UnityEngine;
using UnityEngine.UI; // برای مدیریت UI

public class EnergySlider : MonoBehaviour
{
    public Slider slider; // نوار انرژی
    public PlayerController player; // ارجاع به بازیکن
    private float maxJumpForce = 12f; // مقدار حداکثر پرش
    private float minJumpForce = 3f; // مقدار اولیه پرش

    void Start()
    {
        slider.maxValue = maxJumpForce; // مقدار نهایی نوار برابر 12 باشد
        slider.minValue = minJumpForce; // مقدار اولیه برابر 3 باشد
        slider.value = player.jumpForce; // مقدار اولیه از `jumpForce` دریافت شود
    }

    void Update()
    {
        slider.value = Mathf.Clamp(player.jumpForce, minJumpForce, maxJumpForce); // مقدار نوار بر اساس پرش بروزرسانی شود
    }
}
