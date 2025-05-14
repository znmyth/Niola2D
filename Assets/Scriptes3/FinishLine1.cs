using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject uiMenu; // شیء UI منو

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player")) // بررسی برخورد بازیکن
        {
            Debug.Log("✅ بازیکن وارد درب خروج شد! نمایش منوی UI...");
            uiMenu.SetActive(true); // نمایش UI
            Time.timeScale = 0f; // توقف بازی (اختیاری)
        }
    }
}
